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
    public class IdiomaController : Controller
    {
        private readonly Recruit_DBContext _context;


        public IdiomaController(Recruit_DBContext context)
        {
            _context = context;

        }
        // GET: api/Idioma
        [HttpGet]
        public IEnumerable<TRecIdioma> Get()
        {
            return _context.TRecIdioma.ToList();
        }

        // GET: api/Idioma/5
        [HttpGet("{id}", Name = "IdiomaGet")]
        public TRecIdioma IdiomaGet(int id)
        {
            var idioma = _context.TRecIdioma.FirstOrDefault(e => e.Pkidioma == id);
            if (idioma == null)
            {
                return null;
            }
            return idioma;
        }

        // POST: api/Idioma
        [HttpPost]
        public void Post([FromBody]TRecIdioma value)
        {
            _context.TRecIdioma.Add(value);
            _context.SaveChanges();
        }

        // PUT: api/Idioma/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TRecIdioma value)
        {
            var idioma = _context.TRecIdioma.Where(TRecIdioma => TRecIdioma.Pkidioma == id).First();

            idioma.Descripcionidioma = value.Descripcionidioma;

            _context.SaveChanges();
        }

        // DELETE: api/Idioma/5
        [HttpDelete("{id}")]
        public void Delete(int id, [FromBody]TRecIdioma value)
        {
            var idioma = _context.TRecIdioma.Where(TRecIdioma => TRecIdioma.Pkidioma == id).First();

            _context.TRecIdioma.Remove(idioma);
            _context.SaveChanges();
        }
    }
}
