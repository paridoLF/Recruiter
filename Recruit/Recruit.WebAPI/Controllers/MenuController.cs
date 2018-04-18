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
    [Route("api/Menu")]
    public class MenuController : Controller
    {
        private readonly RecruitContext _context;
        // GET: api/Menu
        [HttpGet]
        public IEnumerable<TSegMenu> Get()
        {
            return _context.TSegMenu.ToList();
            // return new string[] { "value1", "value2" };
        }

        // GET: api/Menu/5
        [HttpGet("{id}", Name = "Get")]
        public TSegMenu Get(int id)
        {

            var list = _context.TSegMenu.Where(TSegMenu => TSegMenu.Pkmenu == id).FirstOrDefault();
            // lamda *** var list = _context.TSegUsuario.FirstOrDefault(TSegUsuario => TSegUsuario.Pkusuario == id);
            if (list == null)
            {
                return null;
                //return no();
            }
            else
            {
                return list;
            }
        }


        // POST: api/Menu
        [HttpPost]
        public void Post([FromBody] TSegMenu value)

        {
            _context.TSegMenu.Add(value);
            _context.SaveChanges();

        }

        // PUT: api/Menu/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TSegMenu value)
        {

            var menu = _context.TSegMenu.FirstOrDefault(u => u.Pkmenu == id);

            if (menu != null)
            {
                menu.Etiquetamenu = value.Etiquetamenu;
                menu.Urlmenu = value.Urlmenu;
                menu.Staturegister = value.Staturegister;
                menu.Fkrol = value.Fkrol;

             

                _context.TSegMenu.Update(menu);
                _context.SaveChanges();
            }
            //else
            //{
            //    return null;
            //}
            ///}

            //return Ok();


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
