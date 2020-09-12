using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public class LoafType
    {
        public LoafType()
        {
            OrderDetails =new HashSet<OrderDetails>();
        }
        public int ID { get; set; }
        public double? plusCost { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<OrderDetails>  OrderDetails { get; set; }
    }
}
