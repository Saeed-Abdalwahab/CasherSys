using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Statics
{
    public enum ShiftStatus
    {
        [Display(Name ="نهاري")]
        Day=0,
        [Display(Name ="ليلي")]

        Night = 1
    }
}
