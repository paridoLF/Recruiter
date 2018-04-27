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
    public class BitacoraController : Controller
    {
        private readonly Recruit_DBContext _context;

        public BitacoraController(Recruit_DBContext context)
        {
            _context = context;

        }


        // GET: api/Bitacora   Obtener listado
        [HttpGet]
        public IEnumerable<TSegBitacora> BitacoraGetAll()
        {
            return _context.TSegBitacora.ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Bitacora/5  Consulta especifica
        [HttpGet("{id}", Name = "BitacoraGet")]
        public TSegBitacora BitacoraGet(int id)
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
        [Route("api/Bitacora/{id}")]
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
        [HttpDelete("{PkBitacora}")]
        [Route("api/Bitacora/{PkBitacora}")]
        public void Delete(int PkBitacora)
        {
            var vBitacora = _context.TSegBitacora.FirstOrDefault(t => t.Pkbitacora == PkBitacora);


            if (vBitacora != null)
            {
                vBitacora.Accionbitacora = "Borrado";

                _context.TSegBitacora.Update(vBitacora);
                _context.SaveChanges();
            }
        }
    }
}
