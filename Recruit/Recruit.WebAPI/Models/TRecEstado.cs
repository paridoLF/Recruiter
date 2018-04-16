using System;
using System.Collections.Generic;

namespace Recruit.WebAPI.Models
{
    public partial class TRecEstado
    {
        public TRecEstado()
        {
            TRecEntrevista = new HashSet<TRecEntrevista>();
        }

        public int Pkestado { get; set; }
        public string Descripcionestado { get; set; }

        public ICollection<TRecEntrevista> TRecEntrevista { get; set; }
    }
}
