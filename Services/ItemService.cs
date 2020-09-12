using DAL;
using DAL.ViewModels;
using Repos.Abstraction;
using Services.Abstraction;
using Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class ItemService : IItemService
    {
        private readonly IRepository<Item> repository;
        private readonly IRepository<ItemDetails> repositoryItemDetails;
        private readonly IUnitOfWork unitOfWork;
        public ItemService(IRepository<Item> repository,IRepository<ItemDetails> repositoryItemDetails,IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.repositoryItemDetails = repositoryItemDetails;
            this.unitOfWork = unitOfWork;
        }
        public int CategoryID(int itemID)
        {
          return  repository.Get(itemID).CategoryID;      
        }
        public IEnumerable<ItemVM> Getall()
        {
            return repository.GetAll().Select(x => new ItemVM { ID = x.ID, Name = x.Name });
        }
        public IEnumerable<ItemVM> GetItemsByCategoryID(int id)
        {
           return repository.Find(x => x.CategoryID == id).Select(x => new ItemVM { ID = x.ID, Name = x.Name });
        }
        public double ItemPrice(int itemDetailsid)
        {
          return  repositoryItemDetails.Get(itemDetailsid).Price;
        }
        public IEnumerable<KeyValueVM> ItemSizes(int itemID)
        {
            return repositoryItemDetails.Find(x => x.ItemID == itemID).Select(x => new KeyValueVM { Key = x.ID, Value = x.Size.GetDisplayName() + "-" + x.Price });
        }
    }
}
