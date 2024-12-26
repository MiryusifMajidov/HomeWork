using EcommerceApiTask.BL.Services.Interfaces;
using EcommerceApiTask.Dal.Interfaces;
using EcommerceApiTask.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApiTask.BL.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Product entity)
        {
             await _repository.AddAsync(entity);
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<Product> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Task HardDelete(int id)
        {
            return _repository.HardDelete(id);
        }

        public Task SoftDelete(int id)
        {
            return _repository.SoftDelete(id);
        }

        public Task Update(Product entity)
        {
            return _repository.Update(entity);
        }
    }
}
