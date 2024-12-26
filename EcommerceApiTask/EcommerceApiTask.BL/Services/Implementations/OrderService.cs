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
    public class OrderService:IOrderService
    {
        private readonly IRepository<Order> _repository;

        public OrderService(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Order entity)
        {
            await _repository.AddAsync(entity);
        }

        public Task<IEnumerable<Order>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<Order> GetById(int id)
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

        public Task Update(Order entity)
        {
            return _repository.Update(entity);
        }
    }
}
