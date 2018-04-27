using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
    //camposrequridos ***

namespace Recruit.MVC.Models
{
    public class UsuarioModel
    {
        [Required]
        public int Pkusuario { get; set; }

        [Display(Name = "Nombre Usuario")]
        //[DisplayAttribute(Name = "Nombre Usuario")]
        [Required]
        public string Nombreusuario { get; set; }

        [Required]
        [Display(Name = "Login Usuario")]
        public string Loginusuario { get; set; }

        [Required]
        [Display(Name = "Clave Usuario")]
        public string Passwordusuario { get; set; }

        [Required]
        [Display(Name = "Cedula Usuario")]
        public string Cedulausuario { get; set; }

        [Required]
        [Display(Name = "Activo Usuario")]
        public bool? Activousuario { get; set; }

        [Required]
        [Display(Name = "Estado Usuario")]
        public bool? Statusregister { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public int Fkrol { get; set; }

    }
}
