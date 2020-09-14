using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels
{
   public class orderDetailsVM
    {
        public int ID { get; set; }
   
        public int itemDetailsID { get; set; }
        
        public int count { get; set; }
        public double totalPrice { get; set; }

        public string notes { get; set; }
    
        public int? OrderID { get; set; }
       
        public int? LoafTypeID { get; set; }
    }
}
