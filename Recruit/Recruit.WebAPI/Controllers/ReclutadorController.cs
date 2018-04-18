﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Recruit.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace Recruit.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Reclutador")]
    public class ReclutadorController : Controller
    {
        private readonly RecruitContext _context;

        // GET: api/Reclutador
        [HttpGet]
        public IEnumerable<TAdmReclutador> Get()
        {
            return _context.TAdmReclutador.ToList();

            //return new string[] { "value1", "value2" };
        }

        // GET: api/Reclutador/5
        [HttpGet("{id}", Name = "Get")]
        public TAdmReclutador Get(int id)
        {
            var queryReclutadores = _context.TAdmReclutador.Where(p => p.Pkreclutador == id);
            if (queryReclutadores == null){
                return null;
            }
            return queryReclutadores.FirstOrDefault();

            //return "value";
        }
        
        // POST: api/Reclutador
        [HttpPost]
        public void Post([FromBody]TAdmReclutador value)
        {
            _context.TAdmReclutador.Add(value);
            _context.SaveChanges();
        }

        // PUT: api/Reclutador/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TAdmReclutador value)
        {
            // Instanciamos el DbContext
            //var dbContext = new testdbEntities();

            // Realizamos la consulta
            var cliente = _context.TAdmReclutador.Where(p => p.Pkreclutador == id).First();



            cliente.Nombrereclutador = value.Nombrereclutador;
            cliente.Telefonoreclutador = value.Telefonoreclutador;
            cliente.Estadoreclutador = value.Estadoreclutador;
            cliente.Correoreclutador = value.Correoreclutador;
          
     
            // Guardamos los cambios
            _context.SaveChanges();



        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            // Realizamos la consulta
            var clienteEliminar = _context.TAdmReclutador.Where(p => p.Pkreclutador == id).First();
            _context.TAdmReclutador.Remove(clienteEliminar);
           
            // Guardamos los cambios
            _context.SaveChanges();


        }
    }
}
