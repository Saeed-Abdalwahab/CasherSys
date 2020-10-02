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
        public double InvoiceCoast { get; set; }
        public double ExtraCost { get; set; }
        public int SandwitchCount { get; set; }

        public List<orderDetailsVM> orderDetailsVMs { get; set; }
    }
}
