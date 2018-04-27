using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recruit.MVC.Models
{
    public class ConfiguracionModel

    {
        [Display(Name = "CORREO")]
        [EmailAddress]
        public string CORREOCONFIGURACION { get; set; }

        [Display(Name = "PATH")]
        public string PATHCONFIGURACION { get; set; }

        [Display(Name = "PK")]
        public int PKCONFIGURACION { get; set; }
    }
}
