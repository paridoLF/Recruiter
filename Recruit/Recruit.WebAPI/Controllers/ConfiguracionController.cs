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
    [Route("api/Configuracion")]
    public class ConfiguracionController : Controller
    {
        private readonly RecruitContext _context;

        // GET: api/Configuracion
        [HttpGet]
        public IEnumerable<TAdmConfiguracion> Get()
        {
            
            return _context.TAdmConfiguracion.ToList();
        }

        // GET: api/Configuracion/5
        [HttpGet("{id}", Name = "Get")]
        //public TAdmConfiguracion Get (String TAdmConfiguracion)
        //{
        //    var TAdmConfiguracion = _context.TAdmConfiguracion.FirstOrDefault();
        //}

        // POST: api/Configuracion
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Configuracion/5
        [HttpPut("{id}")]
        //public void Put(TAdmConfiguracion, [FromBody]string value)
        //{


        //}
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
