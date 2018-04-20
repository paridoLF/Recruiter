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
    public class ConfiguracionController : Controller
    {
        private readonly Recruit_DBContext _context;

        public ConfiguracionController(Recruit_DBContext context)
        {
            _context = context;

        }

        // GET: api/Configuracion
        [HttpGet]
        public IEnumerable<TAdmConfiguracion> Get()
        {
            
            return _context.TAdmConfiguracion.ToList();
        }

        //// GET: api/Configuracion/5
        [HttpGet("{id}", Name = "ConfiguracionGet")]
        public TAdmConfiguracion Get(int id)
        {
            var TAdmConfiguracion = _context.TAdmConfiguracion.FirstOrDefault(c => c.PKCONFIGURACION == id);
            if (TAdmConfiguracion == null)
            {
                return null;
            }

            return TAdmConfiguracion;
        }

        // POST: api/Configuracion/
        [HttpPost]
        public void Post([FromBody]TAdmConfiguracion value)
        {
            _context.TAdmConfiguracion.Add(value);
            _context.SaveChanges();
        }
        
        // PUT: api/Configuracion/5
        [HttpPut]
      
        public void Put(int id, [FromBody] TAdmConfiguracion value)
        {
            var configuarcion = _context.TAdmConfiguracion.FirstOrDefault(c => c.PKCONFIGURACION == value.PKCONFIGURACION);
            configuarcion.CORREOCONFIGURACION = value.CORREOCONFIGURACION;
            configuarcion.PATHCONFIGURACION = value.PATHCONFIGURACION;
            _context.TAdmConfiguracion.Update(configuarcion);
            _context.SaveChanges();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var configuracion = _context.TAdmConfiguracion.Where(c => c.PKCONFIGURACION == id).First();

            _context.TAdmConfiguracion.Remove(configuracion);
            _context.SaveChanges();
        }
    }
}
