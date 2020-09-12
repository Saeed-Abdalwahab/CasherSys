using DAL;
using DAL.ViewModels;
using Repos.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstraction
{
    public interface IOrderService
    {
        OrderVM GetOrderCreate();
       IEnumerable< ItemCategoryVM> GetAllItemCategories(IRepository<itemCategory> repository );

    }
}
