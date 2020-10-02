using DAL;
using DAL.ViewModels;
using Repos.Abstraction;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class DailyExpensesService:IDailyExpensesService
    {
        private readonly IRepository<DailyExpenses> repository;

        public DailyExpensesService(IRepository<DailyExpenses> repository)
        {
            this.repository = repository;
        }
        public IEnumerable<DailyExpensesVM> all()
        {
            return repository.GetAll().Select(x => new DailyExpensesVM { Coast = x.Coast, Date = x.Date, ID = x.ID, Description = x.Description });
        }
        public DailyExpensesVM Get(int id)
        {
            DailyExpensesVM dailyExpensesVM = new DailyExpensesVM();
            var obj = repository.Get(id);
            dailyExpensesVM.ID = obj.ID;
            dailyExpensesVM.Description = obj.Description;
            dailyExpensesVM.Date = obj.Date;
            dailyExpensesVM.Coast = obj.Coast;

            return dailyExpensesVM;
        }
        public DailyExpensesVM addInDb(DailyExpensesVM vM)
        {

            try
            {
                DailyExpenses obj = new DailyExpenses();
                obj.Coast = vM.Coast;
                obj.Date = vM.Date;
                obj.Description = vM.Description;
                var Addedobj = repository.Add(obj);
                vM.ID = Addedobj.ID;
                return vM;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var obj = repository.Get(id);
                repository.Remove(obj);
                return true;

            }
            catch
            {
                return false;
            }
        }
        public DailyExpensesVM Edit(DailyExpensesVM vM)
        {

            try
            {
                DailyExpenses obj = repository.Get(vM.ID);
                obj.Coast = vM.Coast;
                obj.Date = vM.Date;
                obj.Description = vM.Description;
                var Addedobj = repository.Add(obj);
                return vM;
            }
            catch
            {
                return null;
            }
        }

    }
}
