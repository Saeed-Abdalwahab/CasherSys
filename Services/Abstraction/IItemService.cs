using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstraction
{
   public interface IItemService
    {
        IEnumerable<ItemVM> Getall();
        IEnumerable<ItemVM> GetItemsByCategoryID(int id);
        int CategoryID(int itemID);
        IEnumerable<KeyValueVM> ItemSizes(int itemID);
        double ItemPrice(int itemDetailsid);
    }
}
