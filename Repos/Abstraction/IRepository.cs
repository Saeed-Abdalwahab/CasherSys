using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repos.Abstraction
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FristOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        bool Remove(TEntity entity);
        bool RemoveRange(IEnumerable<TEntity> entities);
    }
}
