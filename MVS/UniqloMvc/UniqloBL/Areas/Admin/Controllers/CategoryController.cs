using Microsoft.AspNetCore.Mvc;
using UniqloBT.Service.Implementations;
using UniqloBT.Service.Interface;
using UniqloDAL.DTOs;
using UniqloDAL.Models;

namespace UniqloMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IService<Category> _categoryContext;

        public CategoryController(IService<Category> serviceContext)
        {
            _categoryContext = serviceContext;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryContext.GetAllAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryDto);
            }

            Category category = new Category
            {
                Name = categoryDto.Name,
                CreatedAt = DateTime.Now,
                IsActive = true,
            };

            await _categoryContext.AddAsync(category);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _categoryContext.HardDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var cat = await _categoryContext.GetByIdAsync(id);
            if (cat==null)
            {
                return BadRequest();
            }

            CategoryDto categoryDto = new CategoryDto
            {
                Name = cat.Name,
            };

            return View(nameof(Create),categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryDto);
            }

            Category category = await _categoryContext.GetByIdAsync(id);

            category.Name = categoryDto.Name;
            category.UpdatedAt = DateTime.Now;
       

            await _categoryContext.UpdateAsync(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
