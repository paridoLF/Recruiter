using System;
using System.Collections.Generic;

namespace Recruit.WebAPI.Models
{
    public partial class TRecCandidato 
    {
        public int Pkcandidato { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool Blacklist { get; set; }
        public string Direccion { get; set; }
        public int Añosexperiencia { get; set; }
        public int Estadocivil { get; set; }
    }
}
