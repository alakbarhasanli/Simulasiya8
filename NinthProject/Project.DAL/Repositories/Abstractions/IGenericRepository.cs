﻿using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstractions
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        public DbSet<T> Table {  get; } 
        public Task<ICollection<T>> GetAllAsync();
        public Task<T> GetOneAsync(int id);
        public Task CreateAsync(T entity);
        public void UpdateAsync(T entity);
        public void DeleteAsync(T entity);
        public Task<int> SaveChangesAsync();
    }
}
