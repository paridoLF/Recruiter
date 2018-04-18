using System;
using System.Collections.Generic;

namespace Recruit.WebAPI.Models 
{
    public partial class TRecProbabilidad
    {
        public TRecProbabilidad()
        {
            TRecEntrevista = new HashSet<TRecEntrevista>();
        }

        public int Pkprobabilidad { get; set; }
        public string Descripcionprobabilidad { get; set; }

        public ICollection<TRecEntrevista> TRecEntrevista { get; set; }
    }
}
