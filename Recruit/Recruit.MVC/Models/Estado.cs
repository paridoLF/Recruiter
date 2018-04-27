using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recruit.MVC.Models
{
    public class Estado
    {
        public int Pkestado { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string Descripcionestado { get; set; }
    }
}
