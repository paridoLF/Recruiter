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
    [Route("api/Empresa")]
    public class EmpresaController : Controller
    {
        private readonly RecruitContext _context;


        // GET: api/Empresa
        [HttpGet]
        public IEnumerable<TAdmEmpresa> Get()
        {
            return _context.TAdmEmpresa.ToList();
        }

        // GET: api/Empresa/5
        [HttpGet("{id}", Name = "Get")]
        public TAdmEmpresa Get(int id)
        {
            var empresa = _context.TAdmEmpresa.FirstOrDefault(e => e.Pkempresa == id);
            if (empresa == null)
            {
                return null;
            }
            return empresa;
        }

        // POST: api/Empresa
        [HttpPost]
        public void Post([FromBody] TAdmEmpresa value)
        {
            _context.TAdmEmpresa.Add(value);
            _context.SaveChanges();
        }

        // PUT: api/Empresa/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TAdmEmpresa value)
        {
            var empresa = _context.TAdmEmpresa.FirstOrDefault(e => e.Pkempresa == id);
            empresa.Nombreempresa = value.Nombreempresa;
            empresa.Direccionempresa = value.Direccionempresa;
            empresa.Telefonoempresa = value.Telefonoempresa;
            empresa.Emailempresa = value.Emailempresa;
            empresa.Contactoempresa = value.Contactoempresa;
            empresa.Estadoempresa = value.Estadoempresa;
            _context.TAdmEmpresa.Update(empresa);
            _context.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var empresa = _context.TAdmEmpresa.Where(e => e.Pkempresa == id).First();

            _context.TAdmEmpresa.Remove(empresa);
            _context.SaveChanges();
        }
    }
}
