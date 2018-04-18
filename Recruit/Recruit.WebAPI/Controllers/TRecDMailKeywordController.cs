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
    public class TRecDMailKeywordController : Controller
    {
        private readonly RecruitContext _context;

        // GET: api/TRecDMailKeyword
        [HttpGet]
        public IEnumerable<TRecDetmailkword> Get()
        {
            return _context.TRecDetmailkword.ToList();
        }

        // GET: api/TRecDMailKeyword/5
        [HttpGet("{id}", Name = "TRecDMailKeywordGet")]
        public TRecDetmailkword TRecDetmailkwordGet(int id)
        {
            var Dmkword = _context.TRecDetmailkword.FirstOrDefault(TRecDetmailkword => TRecDetmailkword.Pkdetmailkword == id);

            if (Dmkword == null)
            {
                return null;
            }
            return Dmkword;
        }
        
        // POST: api/TRecDMailKeyword
        [HttpPost]
        public void Post([FromBody]TRecDetmailkword value)
        {
            _context.TRecDetmailkword.Add(value);
            _context.SaveChanges();
        }
        
        // PUT: api/TRecDMailKeyword/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TRecDetmailkword value)
        {
            var Dmkword = _context.TRecDetmailkword.Where(TRecDetmailkword => TRecDetmailkword.Pkdetmailkword == id).First();

            Dmkword.Fkcandmail = value.Fkcandmail;
            Dmkword.Fkkword = value.Fkkword;

            _context.SaveChanges();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Dmkword = _context.TRecDetmailkword.Where(TRecDetmailkword => TRecDetmailkword.Pkdetmailkword == id).First();

            _context.TRecDetmailkword.Remove(Dmkword);
            _context.SaveChanges();
        }
    }
}
