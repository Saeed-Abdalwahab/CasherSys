using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Abstraction
{
   public interface IUnitOfWork:IDisposable
    {
        void Commit();
        void save();
        DbContext context();
        void CreatTransaction();
        void RollBack();

    }
}
