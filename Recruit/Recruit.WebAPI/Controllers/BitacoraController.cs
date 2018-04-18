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
    [Route("api/Bitacora")]
    public class BitacoraController : Controller
    {
        private readonly RecruitContext _context;

        // GET: api/Bitacora   Obtener listado
        [HttpGet]
        public IEnumerable<TSegBitacora> Get()
        {
            return _context.TSegBitacora.ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Bitacora/5  Consulta especifica
        [HttpGet("{id}", Name = "Get")]
        public TSegBitacora Get(int id)
        {
            var vList = _context.TSegBitacora.Where(TSegBitacora => TSegBitacora.Pkbitacora == id).FirstOrDefault();

            if (vList == null)
                return null;
            else
             return vList;
        }
        
        // POST: api/Bitacora     Insertar registro
        [HttpPost]
        public void Post([FromBody]TSegBitacora value)
        {
            _context.TSegBitacora.Add(value);
            _context.SaveChanges();
        }
        
        // PUT: api/Bitacora/5   Actualizar registro
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TSegBitacora value)
        {
            var vBitacora = _context.TSegBitacora.FirstOrDefault(t => t.Pkbitacora == id);


            if (vBitacora != null)
            {
                vBitacora.Accionbitacora = value.Accionbitacora;
                vBitacora.Tablabitacora = value.Tablabitacora;
                vBitacora.Fechabitacora = value.Fechabitacora;
                vBitacora.Registrobitacora = value.Registrobitacora;
                vBitacora.Paginabitacora = value.Paginabitacora;

                _context.TSegBitacora.Update(vBitacora);
                _context.SaveChanges();
            }
        }
        
        // DELETE: api/ApiWithActions/5 Borrar el registro
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var vBitacora = _context.TSegBitacora.FirstOrDefault(t => t.Pkbitacora == id);


            if (vBitacora != null)
            {
                

                _context.TSegBitacora.Update(vBitacora);
                _context.SaveChanges();
            }

        }
    }
}
