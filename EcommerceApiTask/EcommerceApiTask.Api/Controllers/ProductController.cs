using EcommerceApiTask.BL.Services.Interfaces;
using EcommerceApiTask.Model.DTOs.Product;
using EcommerceApiTask.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApiTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var a = await _productService.GetAll();
                return Ok(a);
            }
            catch
            {
                return BadRequest();
            }
           
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var a = _productService.GetById(id);
                return Ok(a);

            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost("AddProduct")]
       public async Task<IActionResult> AddProduct(CreateProductDto createProductDto)
       {
            try
            {

                Product product = new Product
                {
                    Name = createProductDto.Name,
                    Description = createProductDto.Description,
                    Price = createProductDto.Price,
                    Stock = createProductDto.Stock,
                    CreateAt = DateTime.UtcNow
                };
                var a = _productService.AddAsync(product);
                return Ok(a);

            }
            catch
            {
                return BadRequest();
            }

       }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var a = _productService.SoftDelete(id);
                return Ok(a);

            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut]
        public async Task<IActionResult> Update(int id,CreateProductDto productDto)
        {
            try
            {

                var product = await _productService.GetById(id);

                Product updateProduct = new Product
                {
                    Id = product.Id,
                    Name = productDto.Name,
                    Description = productDto.Description,
                    Price = productDto.Price,
                    Stock = productDto.Stock,
                    UpdateAt = DateTime.UtcNow
                };


                var a = _productService.Update(updateProduct);
                return Ok(a);

            }
            catch
            {
                return BadRequest();
            }
        }

       






    }
}
