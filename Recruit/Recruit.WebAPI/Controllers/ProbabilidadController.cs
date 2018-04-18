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
        private readonly RecruitContext _context;
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
            var probabilidad = _context.TRecProbabilidad.FirstOrDefault(m => m.Pkprobabilidad == id);

            if (probabilidad == null)
            {
                return null;
            }
            return probabilidad;
        }

        // POST: api/Probabilidad
        [HttpPost]
        public void Post([FromBody]TRecProbabilidad value)
        {
            _context.TRecProbabilidad.Add(value);
            _context.SaveChanges();
        }

        // PUT: api/Probabilidad/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TRecProbabilidad value)
        {
            var probabilidad = _context.TRecProbabilidad.FirstOrDefault(m => m.Pkprobabilidad == id);

            if (probabilidad != null)
            {
                probabilidad = value;
                probabilidad.Pkprobabilidad = id;
                _context.Update(probabilidad);
                _context.SaveChanges();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var probabilidad = _context.TRecProbabilidad.FirstOrDefault(m => m.Pkprobabilidad == id);

            if (probabilidad != null)
            {
                _context.Remove(probabilidad);
                _context.SaveChanges();
            }
        }
    }
}
