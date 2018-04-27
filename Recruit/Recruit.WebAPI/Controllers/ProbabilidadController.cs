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
    public class ProbabilidadController : Controller
    {
        private readonly Recruit_DBContext _context;

        public ProbabilidadController(Recruit_DBContext context)
        {
            _context = context;

        }
        // GET: api/Probabilidad
        [HttpGet]
        public IEnumerable<TRecProbabilidad> Get()
        {
            return _context.TRecProbabilidad.ToList();
        }

        // GET: api/Probabilidad/5
        [HttpGet("{id}", Name = "ProbabilidadGet")]
        public TRecProbabilidad ProbabilidadGet(int id)
        {
            var probabilidad = _context.TRecProbabilidad.Where(m => m.Pkprobabilidad == id);

            if (probabilidad == null)
            {
                return null;
            }
            return probabilidad.FirstOrDefault();
        }

        // POST: api/Probabilidad
        [HttpPost]
        public void Post([FromBody]TRecProbabilidad value)
        {
            _context.TRecProbabilidad.Add(value);
            _context.SaveChanges();
        }

        // PUT: api/Probabilidad/5
        [HttpPut]
        public void Put(int id, [FromBody]TRecProbabilidad value)
        {
            var cliente = _context.TRecProbabilidad.Where(m => m.Pkprobabilidad == value.Pkprobabilidad).First();

            cliente.Descripcionprobabilidad = value.Descripcionprobabilidad;

            _context.Update(cliente);

            // Guardamos los cambios
            _context.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eliminarProbabilidad = _context.TRecProbabilidad.Where(m => m.Pkprobabilidad == id).First();

            _context.TRecProbabilidad.Remove(eliminarProbabilidad);
            _context.SaveChanges();
         
        }
    }
}
