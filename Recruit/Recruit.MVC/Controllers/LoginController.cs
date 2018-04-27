using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Recruit.MVC.Models;

namespace Recruit.MVC.Controllers
{
    public class LoginController : Controller
    {
        string strApiUrl = "http://localhost:53907/";

        // GET: Login
        public ActionResult Index()
        {

            return View();
        }

        public async Task<bool> Autenticar(string p_strLogin, string p_strClave)
        {
            bool blnValidar = false;

            using (var vCliente = new HttpClient())
            {
                vCliente.BaseAddress = new Uri(strApiUrl);
                vCliente.DefaultRequestHeaders.Accept.Clear();
                vCliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage hrmResponse = await vCliente.GetAsync("api/Usuarios/" + p_strLogin + "/" + p_strClave);
                if (hrmResponse.IsSuccessStatusCode)
                {
                    blnValidar = true;
                }
;
            }

            return blnValidar;
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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