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
    public class TRecCandmailController : Controller
    {
        private readonly Recruit_DBContext _context;

        public TRecCandmailController(Recruit_DBContext context)
        {
            _context = context;

        }
        // GET: api/TRecCandmail
        [HttpGet]
        public IEnumerable<TRecCandmail> Get()
        {
           return _context.TRecCandmail.ToList();
        }

        // GET: api/TRecCandmail/5
        [HttpGet("{idx}", Name = "TRecCandmailGet")]
        public TRecCandmail TRecCandmailGet(int idx)
        {
            var varDatos = _context.TRecCandmail.FirstOrDefault(TRecCandmail => TRecCandmail.Pkcandmail == idx);
            if (varDatos == null){
                return null;
            }
            return varDatos;
        }
        
        // POST: api/TRecCandmail
        [HttpPost]
        public void Post([FromBody]TRecCandmail value)
        {

            _context.TRecCandmail.Add(value);
            _context.SaveChanges();
        }
        
        // PUT: api/TRecCandmail/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TRecCandmail value)

        {
            var todo = _context.TRecCandmail.Where(TRecCandmail => TRecCandmail.Pkcandmail == id).First();
            
            todo.Correo = value.Correo;
            todo.Filename = value.Filename;

            _context.TRecCandmail.Update(todo);
            _context.SaveChanges();

        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var todoborrar = _context.TRecCandmail.Where(TRecCandmail => TRecCandmail.Pkcandmail == id).First();

            _context.TRecCandmail.Remove(todoborrar);
            _context.SaveChanges();
        }
    }
}
