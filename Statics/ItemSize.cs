using System;
using System.ComponentModel.DataAnnotations;

namespace Statics
{
    public enum ItemSize
    {
        [Display(Name ="صغير")]
        Small=1,
        [Display(Name = "متوسط")]
        Medium=2,
        [Display(Name = "كبير")]
        Large=3

    }
}
