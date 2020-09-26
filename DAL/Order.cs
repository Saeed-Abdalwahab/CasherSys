using Statics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public double TotalCoast { get; set; }
        public double ExtraCost { get; set; }
        public double? Discount { get; set; }
        public Int64 ordersnumberForever { get; set; }
        public int OrderNumberForShift { get; set; }
        public bool OrderStatus { get; set; }
        public ShiftStatus shiftStatus { get; set; }
        public virtual IEnumerable<OrderDetails> OrderDetails { get; set; }

    }
}
