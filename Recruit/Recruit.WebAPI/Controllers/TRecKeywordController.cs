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
    [Route("api/TRecKeyword")]
    public class TRecKeywordController : Controller
    {
        private readonly RecruitContext _context;

        // GET: api/TRecKeyword
        [HttpGet]
        public IEnumerable<TRecKeyword> Get()
        {
            return _context.TRecKeyword.ToList();
        }

        // GET: api/TRecKeyword/5
        [HttpGet("{id}", Name = "Get")]
        public TRecKeyword Get(int id)
        {
            var Kword = _context.TRecKeyword.FirstOrDefault(TRecKeyword => TRecKeyword.Pkkword == id);

            if (Kword == null)
            {
                return null;
            }
            return Kword;
        }
        
        // POST: api/TRecKeyword
        [HttpPost]
        public void Post([FromBody]TRecKeyword value)
        {
            _context.TRecKeyword.Add(value);
            _context.SaveChanges();
        }
        
        // PUT: api/TRecKeyword/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TRecKeyword value)
        {
            var Kword = _context.TRecKeyword.Where(TRecKeyword => TRecKeyword.Pkkword == id).First();

            Kword.Keyword = value.Keyword;

            _context.SaveChanges();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Kword = _context.TRecKeyword.Where(TRecKeyword => TRecKeyword.Pkkword == id).First();

            _context.TRecKeyword.Remove(Kword);
            _context.SaveChanges();
        }
    }
}
