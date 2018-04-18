using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruit.WebAPI.Models;


namespace Recruit.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/OfertaTrabajo")]
    public class OfertaTrabajoController : Controller
    {
        private readonly RecruitContext _context;

        // GET: api/OfertaTrabajo
        [HttpGet]
        public IEnumerable<TRecOfertatrabajo> Get()
        {
            return _context.TRecOfertatrabajo.ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/OfertaTrabajo/5
        [HttpGet("{OfertaTrabajoid}")]
        public TRecOfertatrabajo Get(int OfertaTrabajoId)
        {
            var queryOfertaTrabajo = _context.TRecOfertatrabajo.Where(p => p.Pkofertatrabajo == OfertaTrabajoId);

            if (queryOfertaTrabajo == null)
            {
                return null;
            }
            return queryOfertaTrabajo.FirstOrDefault();

            //return "value";
        }
        
        // POST: api/OfertaTrabajo
        [HttpPost]
        public void Post([FromBody]TRecOfertatrabajo value)
        {
            _context.TRecOfertatrabajo.Add(value);
            _context.SaveChanges();

        }
        
        // PUT: api/OfertaTrabajo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TRecOfertatrabajo value)
        {
            var OfertaTrabajo = _context.TRecOfertatrabajo.Where(p => p.Pkofertatrabajo == id).First();

            OfertaTrabajo.Descripcion = value.Descripcion;
            OfertaTrabajo.Empresa = value.Empresa;
            OfertaTrabajo.BeneficiosLab = value.BeneficiosLab;
            OfertaTrabajo.ConocimientosDes = value.ConocimientosDes;
            OfertaTrabajo.ConocimientosReq = value.ConocimientosReq;
            OfertaTrabajo.Labores = value.Labores;
            OfertaTrabajo.NivelIdioma = value.NivelIdioma;
            OfertaTrabajo.Salario = value.Salario;
            OfertaTrabajo.Idioma = value.Idioma;

            _context.Update(OfertaTrabajo);
            _context.SaveChanges();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int idOferta)
        {
            var OfertaTrabajo = _context.TRecOfertatrabajo.Where(p => p.Pkofertatrabajo == idOferta).First();

            _context.TRecOfertatrabajo.Remove(OfertaTrabajo);

            _context.SaveChanges();
        }
    }
}
