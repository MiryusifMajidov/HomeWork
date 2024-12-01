﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InanceDAL.Interfaces
{
	public interface IRepository<T>
	{
		Task<T> GetById(int id);
		Task<T> GetByMaster(int serviceId);
		Task<IEnumerable<T>> GetAll();
		Task AddAsync(T entity);
		Task Update(T entity);
		Task HardDelete(int id);
		Task SoftDelete(int id);
	
	}
}
