using EcommerceApiTask.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApiTask.BL.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<OrderItem> GetById(int id);
        Task<IEnumerable<OrderItem>> GetAll();
        Task AddAsync(OrderItem entity);
        Task Update(OrderItem entity);
        Task HardDelete(int id);
        Task SoftDelete(int id);
    }
}
