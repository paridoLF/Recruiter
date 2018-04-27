using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recruit.MVC.Models
{
    public class OfertaTrabajoModel
    {
        public int Pkofertatrabajo { get; set; }
        [Required]
        [Display(Name="Descripción Oferta")]
        public string Descripcion { get; set; }
        [Required]
        public string Labores { get; set; }
        [Required]
        public string Idioma { get; set; }
        public int NivelIdioma { get; set; }
        public string ConocimientosReq { get; set; }
        public string ConocimientosDes { get; set; }
        public string BeneficiosLab { get; set; }
        public decimal Salario { get; set; }
        public int Empresa { get; set; }

    }
}
