using System;
using System.Collections.Generic;

namespace Recruit.WebAPI.Models
{
    public partial class TOfertaReclutador
    {
        public int Pkofertatrabajo { get; set; }
        public int Pkreclutador { get; set; } 

        public TRecOfertatrabajo PkofertatrabajoNavigation { get; set; }
        public TAdmReclutador PkreclutadorNavigation { get; set; }
    }
}
