using Statics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL
{
   public class ItemDetails
    {
        [Key]
        public int ID { get; set; }
        public ItemSize Size { get; set; }
        public double Price { get; set; }
        public string Discription { get; set; }
        [ForeignKey("Item")]
        public int ItemID { get; set; }
        public virtual Item Item { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
