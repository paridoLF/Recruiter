using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.MVC.Models
{
    public class Entrevista
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
    }
}
