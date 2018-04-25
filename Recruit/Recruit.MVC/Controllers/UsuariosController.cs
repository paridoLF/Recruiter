using System;
using System.Collections.Generic;
using System.Linq;

using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Recruit.MVC.Models;
using System.Net.Http.Formatting;
using System.Net.Http;

namespace Recruit.MVC.Controllers
{
    public class UsuariosController : Controller
    {
        string UrlApi= "http://localhost:53907/";
        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            List<UsuarioModel> UsuariosList = new List<UsuarioModel>();
            using (var cliente = new HttpClient())

            {

                cliente.BaseAddress = new Uri(UrlApi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await cliente.GetAsync("api/Usuarios/");

                if (response.IsSuccessStatusCode)
                {
                    var usuariosResult = response.Content.ReadAsStringAsync().Result;
                    UsuariosList = JsonConvert.DeserializeObject  <List<UsuarioModel>>(usuariosResult);
                }


            }
                return View(UsuariosList);
        }
        
        // GET: Usuarios/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsuarioModel usuarioModel)
        {
            try
            {
                //recibir en json
                //cliente.DefaultRequestHeaders.Accept.Clear();
                //cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var cliente = new HttpClient())

                {

                    cliente.BaseAddress = new Uri(UrlApi + "/api/Usuarios");
                    var PutUsuarios = cliente.PostAsJsonAsync<UsuarioModel>("Usuarios", usuarioModel);
                    PutUsuarios.Wait();
                    //para recibir en json
                    //cliente.DefaultRequestHeaders.Accept.Clear();
                    //cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    /////////////////////////////////
                    // var putUsuarios = cliente.PutAsync();



                    //HttpResponseMessage response = await cliente.PutAsync("api/Usuarios/", id);

                    if (PutUsuarios.Result.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {

                        return View(usuarioModel);
                    }


                }




            }
            catch
            {
                //return View();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            UsuarioModel Usuarios = new UsuarioModel();
   
            using (var cliente = new HttpClient())

            {

                cliente.BaseAddress = new Uri(UrlApi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await cliente.GetAsync("api/Usuarios/" + id);

                if (response.IsSuccessStatusCode)
                {
                    var usuariosResult = response.Content.ReadAsStringAsync().Result;
                    Usuarios = JsonConvert.DeserializeObject<UsuarioModel>(usuariosResult);
                }


            }
            return View(Usuarios);
     
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UsuarioModel usuarioModel)
        {

            try
            {
                //recibir en json
                //cliente.DefaultRequestHeaders.Accept.Clear();
                //cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var cliente = new HttpClient())

                {

                    cliente.BaseAddress = new Uri(UrlApi + "/api/Usuarios");
                    var PutUsuarios = cliente.PutAsJsonAsync<UsuarioModel>("Usuarios", usuarioModel);
                    PutUsuarios.Wait();
                    //para recibir en json
                    //cliente.DefaultRequestHeaders.Accept.Clear();
                    //cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    /////////////////////////////////
                    // var putUsuarios = cliente.PutAsync();



                    //HttpResponseMessage response = await cliente.PutAsync("api/Usuarios/", id);

                    if (PutUsuarios.Result.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {

                        return View(usuarioModel);
                    }


                }


               

            }
            catch
            {
                //return View();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}