using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class Item
    {
        public Item()
        {
            ItemDetails = new List<ItemDetails>();
        }
        public int ID { get; set; }
        public string Name   { get; set; }
        [ForeignKey("ItemCategory")]
        public int CategoryID { get; set; }
        public virtual itemCategory ItemCategory { get; set; }
        public virtual IEnumerable<ItemDetails> ItemDetails { get; set; }

    }
}
