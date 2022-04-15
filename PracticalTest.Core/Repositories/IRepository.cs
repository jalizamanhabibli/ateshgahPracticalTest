using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PracticalTest.Core.Entities;

namespace PracticalTest.Core.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T,bool>> predicate);
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        bool  Update(T entity);
        bool Remove(T entity);
        Task<bool> RemoveAsync(int id);
        bool RemoveRange(IEnumerable<T> entities);



    }
}