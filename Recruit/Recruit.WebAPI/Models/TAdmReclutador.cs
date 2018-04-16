using System;
using System.Collections.Generic;

namespace Recruit.WebAPI.Models
{
    public partial class TAdmReclutador
    {
        public TAdmReclutador()
        {
            TOfertaReclutador = new HashSet<TOfertaReclutador>();
        }

        public int Pkreclutador { get; set; }
        public string Nombrereclutador { get; set; }
        public string Telefonoreclutador { get; set; }
        public string Correoreclutador { get; set; }
        public int? Estadoreclutador { get; set; }

        public ICollection<TOfertaReclutador> TOfertaReclutador { get; set; }
    }
}
