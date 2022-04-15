using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticalTest.Core.Entities;
using PracticalTest.Core.Repositories;

namespace PracticalTest.Repository.Repositories
{
    public class Repository<T>:IRepository<T> where T : BaseEntity
    {
        protected readonly LoanDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(LoanDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return  await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> AddAsync(T entity)
        {
            var result = await _dbSet.AddAsync(entity);
            return result.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return true;
        }

        public bool Update(T entity)
        {
            var result = _dbSet.Update(entity);
            return result.State == EntityState.Modified;
        }

        public bool Remove(T entity)
        {
            var result = _dbSet.Remove(entity);
            return result.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            var result = _dbSet.Remove(entity);
            return result.State == EntityState.Deleted;
        }

        public bool RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return true;
        }
    }
}