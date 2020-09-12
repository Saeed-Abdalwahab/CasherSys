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
        public double? Discount { get; set; }
        public int OrderNumber { get; set; }

        public virtual IEnumerable<OrderDetails> OrderDetails { get; set; }

    }
}
