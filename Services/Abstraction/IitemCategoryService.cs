using DAL;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction
{
    public interface IitemCategoryService
    {
        IEnumerable<ItemCategoryVM> Getall();
        List<JsTreeModel> GetItemsTreeitem();
    }
}
