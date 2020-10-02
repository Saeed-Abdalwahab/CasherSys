using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstraction
{
    public interface IDailyExpensesService
    {
         IEnumerable<DailyExpensesVM> all();
        DailyExpensesVM Edit(DailyExpensesVM vM);
        DailyExpensesVM addInDb(DailyExpensesVM vM);
        DailyExpensesVM Get(int id);
    }
}
