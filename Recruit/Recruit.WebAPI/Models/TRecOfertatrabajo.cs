using System;
using System.Collections.Generic;

namespace Recruit.WebAPI.Models 
{
    public partial class TRecOfertatrabajo
    {
        public TRecOfertatrabajo()
        {
            TOfertaReclutador = new HashSet<TOfertaReclutador>();
        }

        public int Pkofertatrabajo { get; set; }
        public string Descripcion { get; set; }
        public string Labores { get; set; }
        public string Idioma { get; set; }
        public int? NivelIdioma { get; set; }
        public string ConocimientosReq { get; set; }
        public string ConocimientosDes { get; set; }
        public string BeneficiosLab { get; set; }
        public decimal? Salario { get; set; }
        public int? Empresa { get; set; }

        public ICollection<TOfertaReclutador> TOfertaReclutador { get; set; }
    }
}
