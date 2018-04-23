using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Recruit.MVC.Models;

namespace Recruit.MVC.Controllers
{
    public class UsuariosController : Controller
    {
        string UrlApi= "http://localhost:53907/";
        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            List<UsuariosModel> UsuariosList = new List<UsuariosModel>();
            using (var cliente = new HttpClient())

            {

                cliente.BaseAddress = new Uri(UrlApi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await cliente.GetAsync("api/Usuarios/");

                if (response.IsSuccessStatusCode)
                {
                    var usuariosResult = response.Content.ReadAsStringAsync().Result;
                    UsuariosList = JsonConvert.DeserializeObject  <List<UsuariosModel>>(usuariosResult);
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
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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