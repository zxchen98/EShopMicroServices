using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.IRepository;
using OrderAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Infrastructure.Repository
{
    public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : class
    {
        protected readonly OrderDbContext _context;
        public BaseRepositoryAsync(OrderDbContext tb)
        {
            _context = tb;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            return result;
        }

        public Task<int> InsertAsync(T entity)
        {
            _context.Set<T>().AddAsync(entity);
            return _context.SaveChangesAsync();
        }

        public Task<int> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
