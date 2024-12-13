using InanceBL.CustomExtention;
using InanceBL.Services.Interfaces;
using InanceModels.DTOs;
using InanceModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inance.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        private readonly IService<Service> _serviceContext;
        private readonly IService<ServiceImage> _serviceImage;

        public ServiceController(IService<Service> serviceContext, IService<ServiceImage> serviceImage)
        {
            _serviceContext = serviceContext;
            _serviceImage = serviceImage;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _serviceContext.GetAllAsync();

            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ServiceDto serviceDTO, List<IFormFile> Images)
        {
            if (!ModelState.IsValid)
            {
                return View(serviceDTO);
            }

           

            Service service = new Service
            {
                Title = serviceDTO.Title,
                Description = serviceDTO.Description,
                CreatedAt = DateTime.Now,
                IsActive = true
            };
            await _serviceContext.AddAsync(service);


            foreach (var item in Images)
            {
                var uploadedFileName = await item.FileUpload("wwwroot/Images/Service");

                

                ServiceImage serviceImage = new ServiceImage
                {
                    Image = uploadedFileName,
                    ServiceId = service.Id,
                };

               await _serviceImage.AddAsync(serviceImage);

            }


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id) 
        {
            var service = await _serviceContext.GetByIdAsync(id);

            ServiceDto serviceDto = new ServiceDto
            {
                Title = service.Title,
                Description = service.Description,



            };

            ViewBag.Images = await _serviceImage.GetByService(id);
            return View(nameof(Create), serviceDto);
        }
    }
}
