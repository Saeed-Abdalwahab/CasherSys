using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repos.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private  CasherSysContext _DbContext;

        public UnitOfWork(CasherSysContext context)
        {
            this._DbContext = context;
        }
        public  void Commit()
        {

            _DbContext.Database.CommitTransaction();
        }
        public  void CreatTransaction()
        {
            _DbContext.Database.BeginTransaction();
        }
          public  void save()
        {
             this._DbContext.SaveChanges();
        }

        public void Dispose()
        {
            this._DbContext.Dispose();
        }

        public DbContext context()
        {
            return _DbContext;
        }

        public void RollBack()
        {
            _DbContext.Database.RollbackTransaction();
            _DbContext.Dispose();
        }

    }
}
