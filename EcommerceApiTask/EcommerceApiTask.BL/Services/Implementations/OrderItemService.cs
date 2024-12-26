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
    public class OrderItemService:IOrderItemService
    {
        private readonly IRepository<OrderItem> _repository;

        public OrderItemService(IRepository<OrderItem> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(OrderItem entity)
        {
            await _repository.AddAsync(entity);
        }

        public Task<IEnumerable<OrderItem>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<OrderItem> GetById(int id)
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

        public Task Update(OrderItem entity)
        {
            return _repository.Update(entity);
        }
    }
}
