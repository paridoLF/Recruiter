using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recruit.MVC.Models
{
    public class Probabilidad
    {
        public int Pkprobabilidad { get; set; }

        [Required]
        [Display(Name = "Descripción Probabilidad")]
        public string Descripcionprobabilidad { get; set; }
    }
}
