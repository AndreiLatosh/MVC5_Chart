using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class UserData
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимое поле")]
        [Display(Name = "A")]
        public int A { get; set; }

        [Required(ErrorMessage = "Необходимое поле")]
        [Display(Name = "B")]
        public int B { get; set; }

        [Required(ErrorMessage = "Необходимое поле")]
        [Display(Name = "C")]
        public int C { get; set; }

        [Required(ErrorMessage = "Необходимое поле")]
        [Display(Name = "RangeFrom")]
        public int RangeFrom { get; set; }

        [Required(ErrorMessage = "Необходимое поле")]
        [Display(Name = "RangeTo")]
        public int RangeTo { get; set; }

        [Required(ErrorMessage = "Необходимое поле")]
        [Display(Name = "Step")]
        public int Step { get; set; }
    }
}