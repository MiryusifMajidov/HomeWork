﻿using EcommerceApiTask.Dal.DAL;
using EcommerceApiTask.Dal.Interfaces;
using EcommerceApiTask.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApiTask.Dal.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity,new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

        }



        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
           
            return await _context.Set<T>().FindAsync(id);
        }



        public async Task HardDelete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SoftDelete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
