using DAL;
using Microsoft.EntityFrameworkCore;
using Repos.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repos
{
    public class GenaricRepository<Tentity> : IRepository<Tentity> where Tentity : class
    {
        private readonly DbContext _DbContext;
        private readonly DbSet<Tentity> _DbSet;
        public readonly IUnitOfWork _unitOfWork;

        public GenaricRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._DbContext = this._unitOfWork.context();
            this._DbSet = this._DbContext.Set<Tentity>();
        }
    
        public Tentity Add(Tentity entity)
        {
            if (entity == null) return null;
            this._DbSet.Add(entity);
            return entity;
        }
      
        public IEnumerable<Tentity> AddRange(IEnumerable<Tentity> entities)
        {
            if (entities == null) return null;
            this._DbSet.AddRange(entities);
            return entities;
        }

        public IEnumerable<Tentity> Find(Expression<Func<Tentity, bool>> predicate)
        {
          return  this._DbSet.Where(predicate);
        }

        public Tentity FristOrDefault(Expression<Func<Tentity, bool>> predicate)
        {
            return this._DbSet.FirstOrDefault(predicate);
        }

        public Tentity Get(int id)
        {
          return  this._DbSet.Find(id);
        }

        public IEnumerable<Tentity> GetAll()
        {
            return this._DbSet;
        }

        public bool Remove(Tentity entity)
        {
            this._DbSet.Remove(entity);
            return true;

        }

        public bool RemoveRange(IEnumerable<Tentity> entities)
        {
            this._DbSet.RemoveRange(entities);
            return true;
        }



        public Tentity Update(Tentity entity)
        {
            this._DbSet.Attach(entity);
            this._DbContext.Entry(entity).State = EntityState.Modified;
            return entity;

        }

    }
}
