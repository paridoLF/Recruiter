using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.MVC.Models
{
    public class Usuarios
    {
        public int Pkusuario { get; set; }
        public string Nombreusuario { get; set; }
        public string Loginusuario { get; set; }
        public string Passwordusuario { get; set; }
        public string Cedulausuario { get; set; }
        public bool? Activousuario { get; set; }
        public bool? Statusregister { get; set; }
        public int Fkrol { get; set; }

        //public TSegRol FkrolNavigation { get; set; }
    }
}
