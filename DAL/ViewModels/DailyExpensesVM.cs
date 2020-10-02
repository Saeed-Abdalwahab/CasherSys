using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.ViewModels
{
    public class DailyExpensesVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="مطلوب")]
        [Display(Name ="القيمه")]
        [Range(0,double.MaxValue,ErrorMessage ="قيمة غير صحيحه")]
        public double Coast { get; set; }
        [Required(ErrorMessage = "مطلوب")]
        [Display(Name = "وصف المصروف")]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    
    }
}
