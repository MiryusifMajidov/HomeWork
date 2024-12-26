using EcommerceApiTask.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApiTask.BL.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> GetById(int id);
        Task<IEnumerable<Order>> GetAll();
        Task AddAsync(Order entity);
        Task Update(Order entity);
        Task HardDelete(int id);
        Task SoftDelete(int id);
    }
}
