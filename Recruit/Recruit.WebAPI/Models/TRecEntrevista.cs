using System;
using System.Collections.Generic;

namespace Recruit.WebAPI.Models 
{
    public partial class TRecEntrevista
    {
        public int Pkentrevista { get; set; }
        public string Experienciaentrevita { get; set; }
        public string Trabajoantentrevista { get; set; }
        public string Referenciasentrevista { get; set; }
        public decimal Expectsalentrevista { get; set; }
        public int Fkcandidato { get; set; }
        public int Fkestado { get; set; }
        public int Fkidioma { get; set; }
        public int Fkprobabilidad { get; set; }

        public TRecEstado FkestadoNavigation { get; set; }
        public TRecIdioma FkidiomaNavigation { get; set; }
        public TRecProbabilidad FkprobabilidadNavigation { get; set; }
    }
}
