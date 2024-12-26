using EcommerceApiTask.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApiTask.BL.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetById(int id); 
        Task<IEnumerable<Product>> GetAll();
        Task AddAsync(Product entity);
        Task Update(Product entity);
        Task HardDelete(int id);
        Task SoftDelete(int id);
    }
}
