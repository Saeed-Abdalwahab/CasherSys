using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.ViewModels
{
  public  class OrderVM
    {
        public OrderVM()
        {
            orderDetailsVMs = new List<orderDetailsVM>();
        }
        public int ID { get; set; }
        [Required]
        [Display(Name ="التاريخ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [Display(Name ="اجمالي")]

        public double TotalCoast { get; set; }
        [Display(Name ="الخصم")]

        public double? Discount { get; set; }
        [Display(Name ="رقم الطلب")]
        [Required(ErrorMessage ="*")]
        public int OrderNumber { get; set; }
        [Range(0, double.MaxValue ,ErrorMessage ="قيمة غير صحيحه")]
        public double? ExtraCost { get; set; }

        public List<orderDetailsVM> orderDetailsVMs { get; set; }
    }
}
