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
    public class EstadoController : Controller
    {
        private readonly RecruitContext _context;   
        // GET: api/Estado
        [HttpGet]
        public IEnumerable<TRecEstado> Get()
        {
            return _context.TRecEstado.ToList();
        }

        // GET: api/Estado/5
        [HttpGet("{id}", Name = "EstadoGet")]
        public TRecEstado EstadoGet(int id)
        {
           var estado = _context.TRecEstado.FirstOrDefault(e => e.Pkestado == id);
           if (estado == null)
            {
                return null;
            }
            return estado;
        }
        
        // POST: api/Estado
        [HttpPost]
        public void Post([FromBody]TRecEstado value)
        {
            _context.TRecEstado.Add(value);
            _context.SaveChanges();
        }
        
        // PUT: api/Estado/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TRecEstado value)
        {
            var estado = _context.TRecEstado.FirstOrDefault(e => e.Pkestado == id);
            if (estado != null)
            {
                estado = value;
                estado.Pkestado = id;
                _context.Update(estado);
                _context.SaveChanges();
            }
        }

        // DELETE: api/Estado/5
        [HttpDelete("{id}")]
        public void Delete(int id, [FromBody]TRecEstado value)
        {
            var estado = _context.TRecEstado.FirstOrDefault(e => e.Pkestado == id);
            if (estado != null)
            {
                _context.Remove(estado);
                _context.SaveChanges();
            }
        }
    }
}
