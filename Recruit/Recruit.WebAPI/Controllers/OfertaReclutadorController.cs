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
    [Route("api/[controller]")]
    public class OfertaReclutadorController : Controller
    {

        private readonly RecruitContext _context;

        // GET: api/OfertaReclutador
        [HttpGet]
      
        public IEnumerable<TOfertaReclutador> Get()
        {
            return _context.TOfertaReclutador.ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/OfertaReclutador/5/5
        [HttpGet("{oid}/{rid}", Name = "OfertaReclutadorGet")]
        

        public TOfertaReclutador OfertaReclutadorGet(int OfertaId,int ReclutadorId)
        {
            var queryOfertaReclutador = _context.TOfertaReclutador.Where(p => p.Pkofertatrabajo == OfertaId && p.Pkreclutador == ReclutadorId);

            if (queryOfertaReclutador == null)
            {
                return null;
            }
            return queryOfertaReclutador.FirstOrDefault();

            //return "value";
        }

        // POST: api/OfertaReclutador
        [HttpPost]
        public void Post([FromBody]TOfertaReclutador value)
        {
            _context.TOfertaReclutador.Add(value);
            _context.SaveChanges();
        }


        // PUT: api/OfertaReclutador/5/5
        [HttpPut("{oid}/{rid}")]
   
        public void Put(int OfertaId, int ReclutadorId, [FromBody]TOfertaReclutador value)
        {
            var OfertaReclutador = _context.TOfertaReclutador.Where(p => p.Pkofertatrabajo == OfertaId && p.Pkreclutador == ReclutadorId).First();

            OfertaReclutador.Pkofertatrabajo = value.Pkofertatrabajo;
            OfertaReclutador.Pkreclutador = value.Pkreclutador;

            _context.Update(OfertaReclutador);

            _context.SaveChanges();
        }


        // DELETE: api/ApiWithActions/5/5
        [HttpDelete("{oid}/{rid}")]
       
        public void Delete(int OfertaId, int ReclutadorId)
        {
            var OfertaReclutador = _context.TOfertaReclutador.Where(p => p.Pkofertatrabajo == OfertaId && p.Pkreclutador == ReclutadorId).First();

            _context.TOfertaReclutador.Remove(OfertaReclutador);

            _context.SaveChanges();
        }
    }
}
