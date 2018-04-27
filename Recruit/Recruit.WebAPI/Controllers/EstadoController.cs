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
        private readonly Recruit_DBContext _context;


        public EstadoController(Recruit_DBContext context)
        {
            _context = context;

        }
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
        [HttpPut]
        public void Put([FromBody]TRecEstado value)
        {
            var cliente = _context.TRecEstado.Where(p => p.Pkestado == value.Pkestado).First();
           
            cliente.Descripcionestado = value.Descripcionestado;

            _context.Update(cliente);

            _context.SaveChanges();
        }

        // DELETE: api/ApiWithAction/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var clienteEliminar = _context.TRecEstado.Where(p => p.Pkestado == id).First();

            _context.TRecEstado.Remove(clienteEliminar);
            _context.SaveChanges();

        }
    }
}
