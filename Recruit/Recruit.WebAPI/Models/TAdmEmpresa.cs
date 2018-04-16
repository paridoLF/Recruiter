using System;
using System.Collections.Generic;

namespace Recruit.WebAPI.Models
{
    public partial class TAdmEmpresa
    {
        public int Pkempresa { get; set; }
        public string Nombreempresa { get; set; }
        public string Direccionempresa { get; set; }
        public string Telefonoempresa { get; set; }
        public string Emailempresa { get; set; }
        public string Contactoempresa { get; set; }
        public bool? Estadoempresa { get; set; }
    }
}
