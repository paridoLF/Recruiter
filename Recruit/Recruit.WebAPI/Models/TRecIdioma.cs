using System;
using System.Collections.Generic;

namespace Recruit.WebAPI.Models
{
    public partial class TRecIdioma
    {
        public TRecIdioma()
        {
            TRecEntrevista = new HashSet<TRecEntrevista>();
        }

        public int Pkidioma { get; set; }
        public string Descripcionidioma { get; set; }

        public ICollection<TRecEntrevista> TRecEntrevista { get; set; }
    }
}
