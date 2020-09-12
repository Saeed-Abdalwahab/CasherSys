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
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> repository;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IRepository<Order> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public OrderVM GetOrderCreate()
        {
            OrderVM creatOrderVM = new OrderVM();
            var lastOrder = repository.GetAll().LastOrDefault();
            creatOrderVM.OrderNumber = lastOrder == null ? 1 : lastOrder.OrderNumber + 1;
            creatOrderVM.Date = DateTime.Now;
            return creatOrderVM;
        }

        public IEnumerable<ItemCategoryVM> GetAllItemCategories(IRepository<itemCategory> repository)
        {
           return repository.GetAll().Select(x=>new ItemCategoryVM { 
           ID=x.ID,
           Name=x.Name
           });
        }

      

    }
}
