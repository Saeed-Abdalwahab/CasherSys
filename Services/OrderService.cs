using DAL;
using DAL.ViewModels;
using Repos.Abstraction;
using Services.Abstraction;
using Statics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            var ShiftDayTime = TimeSpan.Parse("03:59:59", System.Globalization.CultureInfo.CurrentCulture);

            var lastOrder = repository.GetAll().LastOrDefault();
            var FirstOrderOfDay = repository.Find(x => x.OrderNumberForShift == 1).LastOrDefault();

            creatOrderVM.OrderNumber =
                FirstOrderOfDay == null || DateTime.Compare(DateTime.Now, (FirstOrderOfDay.Date.Date + ShiftDayTime).AddHours(24)) > 0 ? 
                1 : lastOrder.OrderNumberForShift + 1;
                





           // var TimeNow = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"), System.Globalization.CultureInfo.CurrentCulture);
           //     creatOrderVM.OrderNumber = lastOrder != null && DateTime.Now.Subtract(lastOrder.Date).Days == 0 ? //Check If No Data In Order And If The last order From More Than 1 Day
           //(TimeSpan.Compare(ShiftDayTime,TimeNow ) > 0 && lastOrder.OrderNumberForShift >= 1 ? 1 : lastOrder.OrderNumberForShift + 1) // Check If The Time Now More Than 3.59 AM
           //: 1;

       
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
            order.Date = orderVM.Date;

            order.shiftStatus = 0;

            var lastOrder = repository.GetAll().LastOrDefault();

            order.ordersnumberForever = repository.GetAll().Count() + 1;
            order.ExtraCost = orderVM.ExtraCost==null|| orderVM.ExtraCost <0 ? 0:(double)orderVM.ExtraCost;
            order.OrderNumberForShift = orderVM.OrderNumber;
            order.TotalCoast = orderVM.TotalCoast;


            try
            {
                unitOfWork.CreatTransaction();
                repository.Add(order);
                unitOfWork.save();
           var itemDetails= orderVM.orderDetailsVMs.Select(item => new OrderDetails
                {
                    count = item.count,
                    itemDetailsID = item.itemDetailsID,
                    LoafTypeID = item.LoafTypeID,
                    notes = item.notes,
                    OrderID = order.ID,
                    totalPrice = item.totalPrice,
                }).ToList();
                orderdetailsrepo.AddRange(itemDetails);
                unitOfWork.save();

                //foreach (var item in orderVM.orderDetailsVMs)
                //{
                //    OrderDetails orderDetails = new OrderDetails();
                //    orderDetails.count = item.count;
                //    orderDetails.itemDetailsID = item.itemDetailsID;
                //    orderDetails.LoafTypeID = item.LoafTypeID;
                //    orderDetails.notes = item.notes;
                //    orderDetails.OrderID = order.ID;
                //    orderDetails.totalPrice = item.totalPrice;
                //    orderdetailsrepo.Add(orderDetails);
                //    unitOfWork.save();
                //}

                unitOfWork.Commit();
            }
            catch
            {

                unitOfWork.RollBack();
            }
            return false;
        }

        public Order GetOrder(int OrderID)
        {
            return repository.Get(OrderID);
        }
        public IEnumerable<Order> AllToDayOrders()
        {
           
            var ShiftDayTime = TimeSpan.Parse("03:59:59", System.Globalization.CultureInfo.CurrentCulture);
            var StartShiftDateOfDay = ShiftStartDateOfDay();
            var ss= repository.Find(x => x.Date >=StartShiftDateOfDay);
            //return repository.Find(x=> x.Date>=(DateTime.Now.Date+ShiftDayTime));
            return ss;
        }

        public List<OrderReportVM> OrderReportSource(int OrderID)
        {
            List<OrderReportVM> list = new List<OrderReportVM>();
            OrderReportVM orderReportVM = new OrderReportVM();
            var Order = GetOrder(OrderID);
            orderReportVM.orderDetailsVMs = Order.OrderDetails.Select(x => new orderDetailsVM
            {
                count = x.count,
                LoafTypeName = x.LoafType.Name,
                notes = x.notes,
                ItemName = x.ItemDetails.Item.Name,
                totalPrice = x.totalPrice,
                ItemPrice = x.ItemDetails.Price.ToString()
            }).ToList();
            orderReportVM.OrderNumber = Order.OrderNumberForShift.ToString();
            orderReportVM.Date = Order.Date.ToString("dd/MM/yyyy");
            orderReportVM.Time = Order.Date.ToShortTimeString();
            orderReportVM.CasherName = "Mohanad";
            orderReportVM.InvoiceCoast = Order.TotalCoast;
            orderReportVM.ExtraCost = Order.ExtraCost;
            orderReportVM.SandwitchCount = Order.OrderDetails.Sum(x => x.count);
            list.Add(orderReportVM);
            return list;
        }

        private DateTime ShiftStartDateOfDay()
        {
            var ShiftStartDate = DateTime.Now.Date+ TimeSpan.Parse("03:59:59", System.Globalization.CultureInfo.CurrentCulture);
            return DateTime.Compare(ShiftStartDate, DateTime.Now) > 0 ? ShiftStartDate.AddDays(-1) : ShiftStartDate;
        }

    }
}
