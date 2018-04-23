using System;
using System.Collections.Generic;

namespace Recruit.MVC.Models 
{
    public partial class Bitacora
    {
        public int Pkbitacora { get; set; }
        public string Accionbitacora { get; set; }
        public string Tablabitacora { get; set; }
        public DateTime Fechabitacora { get; set; }
        public string Registrobitacora { get; set; }
        public string Paginabitacora { get; set; }
    }
}
