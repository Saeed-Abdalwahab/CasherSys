using DAL;
using DAL.ViewModels;
using Repos.Abstraction;
using Services.Abstraction;
using Statics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<OrderDetails> orderdetailsrepo;

        public OrderService(IRepository<Order> repository, IUnitOfWork unitOfWork, IRepository<OrderDetails> orderdetailsrepo)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.orderdetailsrepo = orderdetailsrepo;
        }
        public OrderVM GetOrderCreate()
        {
            OrderVM creatOrderVM = new OrderVM();
          
            var lastOrder = repository.GetAll().LastOrDefault();
            var ShiftDayTime = TimeSpan.Parse("03:59:59", System.Globalization.CultureInfo.CurrentCulture);
            var TimeNow = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"), System.Globalization.CultureInfo.CurrentCulture);
            

                creatOrderVM.OrderNumber = lastOrder != null && DateTime.Now.Subtract(lastOrder.Date).Days == 0 ? //Check If No Data In Order And If The last order From More Than 1 Day
           (TimeSpan.Compare(TimeNow, ShiftDayTime) > 0 && lastOrder.OrderNumberForShift > 1 ? 1 : lastOrder.OrderNumberForShift + 1) // Check If The Time Now More Than 3.59 AM
           : 1;


            creatOrderVM.Date = DateTime.Now;
            return creatOrderVM;
        }

        public IEnumerable<ItemCategoryVM> GetAllItemCategories(IRepository<itemCategory> repository)
        {
            return repository.GetAll().Select(x => new ItemCategoryVM
            {
                ID = x.ID,
                Name = x.Name
            });
        }

        public bool SaveOrderInDb(OrderVM orderVM)
        {
            Order order = new Order();
            order.Date = DateTime.Now;

            order.shiftStatus = 0;

            var lastOrder = repository.GetAll().LastOrDefault();

            order.ordersnumberForever = repository.GetAll().Count() + 1;
            var ShiftDayTime = TimeSpan.Parse("03:59:59", System.Globalization.CultureInfo.CurrentCulture);
            var TimeNow = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"), System.Globalization.CultureInfo.CurrentCulture);


            order.OrderNumberForShift = lastOrder != null && DateTime.Now.Subtract(lastOrder.Date).Days == 0 ? //Check If No Data In Order And If The last order From More Than 1 Day
           (TimeSpan.Compare(TimeNow, ShiftDayTime) > 0 && lastOrder.OrderNumberForShift > 1 ? 1 : lastOrder.OrderNumberForShift + 1) // Check If The Time Now More Than 3.59 AM
           : 1;
            order.TotalCoast = orderVM.TotalCoast;


            try
            {
                unitOfWork.CreatTransaction();
                repository.Add(order);
                unitOfWork.save();

                foreach (var item in orderVM.orderDetailsVMs)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.count = item.count;
                    orderDetails.itemDetailsID = item.itemDetailsID;
                    orderDetails.LoafTypeID = item.LoafTypeID;
                    orderDetails.notes = item.notes;
                    orderDetails.OrderID = order.ID;
                    orderDetails.totalPrice = item.totalPrice;
                    orderdetailsrepo.Add(orderDetails);
                    unitOfWork.save();
                }

                unitOfWork.Commit();
            }
            catch
            {

                unitOfWork.RollBack();
            }
            return false;
        }

    }
}
