using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels
{
   public class OrderReportVM
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string CasherName { get; set; }
        public string OrderNumber { get; set; }
        public Order Order { get; set; }
    }
}
