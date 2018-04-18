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
    [Route("api/Entrevista")]
    public class EntrevistaController : Controller
    {
        private readonly RecruitContext _context;
        // GET: api/Entrevista
        [HttpGet]
        public IEnumerable<TRecEntrevista> Get()
        {
            return _context.TRecEntrevista.ToList();
        }

        // GET: api/Entrevista/5
        [HttpGet("{id}", Name = "Get")]
        public TRecEntrevista Get(int id)
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
            var entrevista = _context.TRecEntrevista.FirstOrDefault(m => m.Pkentrevista == id);

            if (entrevista != null)
            {
                entrevista = value;
                entrevista.Pkentrevista = id;
                _context.Update(entrevista);
                _context.SaveChanges();
            }
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
