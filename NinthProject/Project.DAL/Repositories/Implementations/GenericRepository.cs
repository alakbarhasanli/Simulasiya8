using Microsoft.EntityFrameworkCore;
using Project.DAL.Contexts;
using Project.DAL.Entities;
using Project.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly NinthDbContext _context;

        public GenericRepository(NinthDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
           return await Table.ToListAsync();
        }

        public async Task<T> GetOneAsync(int id)
        {
            var oneEntity=await Table.SingleOrDefaultAsync(x => x.Id == id);
            return oneEntity;
        }
        public void DeleteAsync(T entity)
        {
            Table.Remove(entity);
        }


        public async Task<int> SaveChangesAsync()
        {
            int rows=await _context.SaveChangesAsync();
            return rows;
        }

        public void UpdateAsync(T entity)
        {
            Table.Update(entity);
        }
    }
}
