﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.MVC.Models
{
    public class EmpresaModel
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