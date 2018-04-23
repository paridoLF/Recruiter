using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.MVC.Models
{
    public class TRecCandidatoModel
    {
        public int Pkcandidato { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int Blacklist { get; set; }
        public string Direccion { get; set; }
        public int Añosexperiencia { get; set; }
        public int Estadocivil { get; set; }
    }
}
