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
        bool SaveOrderInDb(OrderVM orderVM);
       IEnumerable< ItemCategoryVM> GetAllItemCategories(IRepository<itemCategory> repository );
        Order GetOrder(int OrderID);
        IEnumerable<Order> AllOrders();
    }
}
