using Statics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels
{
  public  class ItemDetailsVM
    {
        public int ID { get; set; }
        public ItemSize Size { get; set; }
        public double Price { get; set; }
        public string Discription { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
    }
}
