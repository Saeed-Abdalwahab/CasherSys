using DAL;
using DAL.ViewModels;
using Repos.Abstraction;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class ItemCategoryService : IitemCategoryService
    {
        private readonly IRepository<itemCategory> repository;
        private readonly IUnitOfWork unitOfWork;

        public ItemCategoryService(IRepository<itemCategory> repository,IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }



        public IEnumerable<ItemCategoryVM> Getall()
        {
            return repository.GetAll().Select(x => new ItemCategoryVM
            {
                ID = x.ID,
                Name = x.Name
            }) ;
        }
        public List<JsTreeModel> GetItemsTreeitem()
        {

            return repository.GetAll().Select(x => new JsTreeModel
            {
                text = x.Name,
                icon= "fa fa - list - ul",
                state=new JsTreeModelstate() { opened=true,disabled=true},
                children = x.items.Select(xx => new JsTreeModel
                {
                    id = xx.ID.ToString(),
                    text = xx.Name
                }).ToList()
            }).ToList();

        }

        
    }
}
