using EcommerceApiTask.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApiTask.Dal.Interfaces
{
    public interface IRepository<T> where T:BaseEntity,new()
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task AddAsync(T entity);
        Task Update(T entity);
        Task HardDelete(int id);
        Task SoftDelete(int id);

    }
}
