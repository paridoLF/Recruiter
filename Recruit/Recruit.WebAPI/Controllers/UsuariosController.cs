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

    public class UsuariosController : Controller
    {
        private readonly Recruit_DBContext _context;


        // GET: api/Usuarios
        [HttpGet]
        public IEnumerable<TSegUsuario> UsuariosGetAll()
        {
            return _context.TSegUsuario.ToList();
            // return new string[] { "value1", "value2" };
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "UsuariosGet")]
        public TSegUsuario UsuariosGet(int id)
        {

            var list = _context.TSegUsuario.Where(TSegUsuario => TSegUsuario.Pkusuario == id).FirstOrDefault();
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
        
        // POST: api/Usuarios INSERT
        [HttpPost]
        public void Post([FromBody] TSegUsuario value)
            
        {
            _context.TSegUsuario.Add(value);
            _context.SaveChanges();

            

            
        }
        
        // PUT: api/Usuarios/ UPDATE
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TSegUsuario value)
        {
          
                var usuarios = _context.TSegUsuario.FirstOrDefault(u => u.Pkusuario == id);

                if (usuarios != null)
                {
                    usuarios.Nombreusuario = value.Nombreusuario;
                    usuarios.Loginusuario = value.Loginusuario;
                    usuarios.Passwordusuario = value.Passwordusuario;
                    usuarios.Cedulausuario = value.Cedulausuario;

                    usuarios.Activousuario = value.Activousuario;
                    usuarios.Statusregister = value.Statusregister;
                    usuarios.Fkrol = value.Fkrol;

                    _context.TSegUsuario.Update(usuarios);
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

            var usuarios = _context.TSegUsuario.FirstOrDefault(u => u.Pkusuario == id);

            if (usuarios != null)
            {
              
                usuarios.Activousuario = false;

                _context.TSegUsuario.Update(usuarios);
                _context.SaveChanges();
            }


        }
    }
}
