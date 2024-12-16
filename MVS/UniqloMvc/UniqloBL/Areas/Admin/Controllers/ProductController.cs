using Microsoft.AspNetCore.Mvc;
using UniqloBT.Service.Interface;
using UniqloDAL.DTOs;
using UniqloDAL.Models;

namespace UniqloMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IService<Product> _productContext;
        private readonly IService<Category> _categoryContext;

        public ProductController(IService<Product> productContext, IService<Category> categoryContext)
        {
            _productContext = productContext;
            _categoryContext = categoryContext;
        }

        public async Task<IActionResult> Index()
        {
            var product = await _productContext.GetAllAsync();
            return View(product);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Category = await _categoryContext.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Category = await _categoryContext.GetAllAsync();

                return View(productDto);
            };

            Product product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Image = productDto.Image,
                CategoryId = productDto.CategoryId,
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            await _productContext.AddAsync(product);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
