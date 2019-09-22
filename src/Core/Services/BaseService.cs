using Core.Data;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class BaseService<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _db;
        protected readonly IConfiguration _configuration;
        protected readonly ILogger _logger;


        public BaseService(ApplicationDbContext db, IConfiguration configuration, ILogger logger)
        {
            _db = db;
            _configuration = configuration;
            _logger = logger;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            System.Diagnostics.Debug.WriteLine(entity);
            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

       /*public async Task DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }*/
        public async Task<T> DeleteAsync(Guid id)
        {
            var item = await _db.Set<T>().FindAsync(id);

            _db.Set<T>().Remove(item);
            await _db.SaveChangesAsync();
            return item;
        }
    }
}
