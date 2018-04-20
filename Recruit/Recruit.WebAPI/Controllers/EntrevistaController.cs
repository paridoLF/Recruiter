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
    public class EntrevistaController : Controller
    {
        private readonly Recruit_DBContext _context;

        public EntrevistaController(Recruit_DBContext context)
        {
            _context = context;

        }
        // GET: api/Entrevista
        [HttpGet]
        public IEnumerable<TRecEntrevista> Get()
        {
            return _context.TRecEntrevista.ToList();
        }

        // GET: api/Entrevista/5
        [HttpGet("{id}", Name = "EntrevistaGet")]
        public TRecEntrevista EntrevistaGet(int id)
        {
            var entrevista = _context.TRecEntrevista.FirstOrDefault(m => m.Pkentrevista == id);

            if (entrevista == null)
            {
                return null;
            }
            return entrevista;
        }

        // POST: api/Entrevista
        [HttpPost]
        public void Post([FromBody]TRecEntrevista value)
        {
            _context.TRecEntrevista.Add(value);
            _context.SaveChanges();
        }

        // PUT: api/Entrevista/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TRecEntrevista value)
        {
            var entrevista = _context.TRecEntrevista.Where(p => p.Pkentrevista == id).First();
            //_context.TRecOfertatrabajo.Where(p => p.Pkofertatrabajo == id).First();

            //if (entrevista != null)
            //{
            //    entrevista.Pkentrevista = id;
                entrevista.Expectsalentrevista = value.Expectsalentrevista;
                entrevista.Experienciaentrevita = value.Experienciaentrevita;
                entrevista.Referenciasentrevista = value.Referenciasentrevista;
                entrevista.Trabajoantentrevista = value.Trabajoantentrevista;
                entrevista.Fkcandidato = value.Fkcandidato;
                entrevista.Fkestado = value.Fkestado;
                entrevista.Fkidioma = value.Fkidioma;
                entrevista.Fkprobabilidad = value.Fkprobabilidad;

                //_context.Update(entrevista);
                _context.SaveChanges();
            //}
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entrevista = _context.TRecEntrevista.FirstOrDefault(m => m.Pkentrevista == id);

            if (entrevista != null)
            {
                _context.Remove(entrevista);
                _context.SaveChanges();
            }
        }
    }
}
