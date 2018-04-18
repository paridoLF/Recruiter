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
    [Route("api/TRecCandidato")]
    public class TRecCandidatoController : Controller
    {
        private readonly RecruitContext _context;

        // GET: api/TRecCandidato
        [HttpGet]
        public IEnumerable<TRecCandidato> Get()
        {
            return _context.TRecCandidato.ToList();
        }

        // GET: api/TRecCandidato/5
        [HttpGet("{id}", Name = "Get")]
        public TRecCandidato Get(int id)
        {
            var Candidato = _context.TRecCandidato.FirstOrDefault(TRecCandidato => TRecCandidato.Pkcandidato == id);

            if (Candidato == null)
            {
                return null;
            }
            return Candidato;
        }

    

        // POST: api/TRecCandidato
        [HttpPost]
        public void Post([FromBody]TRecCandidato value)
        {
            _context.TRecCandidato.Add(value);
            _context.SaveChanges();
        }
        
        
        // PUT: api/TRecCandidato/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TRecCandidato value)
        {
            var candidato = _context.TRecCandidato.Where(TRecCandidato => TRecCandidato.Pkcandidato == id).First();

            candidato.Nombre = value.Nombre;
            candidato.Estado = value.Estado;
            candidato.Telefono = value.Telefono;
            candidato.Correo = value.Correo;
            candidato.Blacklist = value.Blacklist;
            candidato.Añosexperiencia = value.Añosexperiencia;
            candidato.Estadocivil = value.Estadocivil;

            _context.SaveChanges();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var candidato = _context.TRecCandidato.Where(TRecCandidato => TRecCandidato.Pkcandidato == id).First();

            _context.TRecCandidato.Remove(candidato);
            _context.SaveChanges();
        }
    }
}
