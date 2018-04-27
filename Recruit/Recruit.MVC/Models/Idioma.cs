using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recruit.MVC.Models
{
    public class Idioma
    {
        public int Pkidioma { get; set; }
        
        [Required]
        [Display(Name = "Idioma")]
        public string Descripcionidioma { get; set; }
    }
}
