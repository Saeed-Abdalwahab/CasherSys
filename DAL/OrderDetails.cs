using Statics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL
{
   public class OrderDetails
    {
        public int ID { get; set; }
        [ForeignKey("ItemDetails")]
        public int   itemDetailsID { get; set; }
        public int count { get; set; }
        public double totalPrice { get; set; }
       
        public string notes { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        [ForeignKey("LoafType")]
        public int? LoafTypeID { get; set; }
        public virtual Order Order { get; set; }

        public virtual ItemDetails ItemDetails { get; set; }
        public virtual LoafType LoafType { get; set; }
    }
}
