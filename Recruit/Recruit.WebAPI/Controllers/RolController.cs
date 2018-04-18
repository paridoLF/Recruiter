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
    public class RolController : Controller
    {

        private readonly Recruit_DBContext _context;

        public RolController(Recruit_DBContext context)
        {
            _context = context;

        }

        // GET: api/Rol
        [HttpGet]
        public IEnumerable<TSegRol> RolGetAll()
        {
            return _context.TSegRol.ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Rol/5
        [HttpGet("{id}", Name = "GetRol")]
        public TSegRol RolGet(int id)
        {
            var vList = _context.TSegRol.Where(TSegRol => TSegRol.Pkrol == id).FirstOrDefault();

            if (vList == null)
                return null;
            else
                return vList;
        }
        
        // POST: api/Rol
        [HttpPost]
        public void Post([FromBody]TSegRol value)
        {
            _context.TSegRol.Add(value);
            _context.SaveChanges();

        }
        
        // PUT: api/Rol/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TSegRol value)
        {
            var vRol = _context.TSegRol.FirstOrDefault(t => t.Pkrol == id);


            if (vRol != null)
            {
                vRol.Nombrerol = value.Nombrerol;

                _context.TSegRol.Update(vRol);
                _context.SaveChanges();
            }

        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
