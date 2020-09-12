using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL
{
  public  class itemCategory
    {
        public itemCategory()
        {
            items = new List<Item>();
        }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Item> items { get; set; }
    }
}
