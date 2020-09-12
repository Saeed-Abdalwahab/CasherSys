using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.ViewModels
{
  public  class OrderVM
    {
        [Required]
        [Display(Name ="التاريخ")]

        public DateTime Date { get; set; }
        [Display(Name ="اجمالي")]

        public double TotalCoast { get; set; }
        [Display(Name ="الخصم")]

        public double? Discount { get; set; }
        [Display(Name ="رقم الطلب")]
        [Required(ErrorMessage ="*")]
        public int OrderNumber { get; set; }
    }
}
