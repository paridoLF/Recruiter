using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Recruit.MVC.Models;

namespace Recruit.MVC.Controllers
{
    public class BitacoraController : Controller
    {
        // GET: Bitacora
        public async Task<IActionResult> Index()
        {
            string strApiUrl = "http://localhost:53907";

            List<Bitacora> lstBitacora = new List<Bitacora>();

            using (var vCliente = new HttpClient())
            {
                vCliente.BaseAddress = new Uri(strApiUrl);
                vCliente.DefaultRequestHeaders.Accept.Clear();
                vCliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage hrmResponse = await vCliente.GetAsync("api/Bitacora/");
                if (hrmResponse.IsSuccessStatusCode)
                {
                    var vBitacora = hrmResponse.Content.ReadAsStringAsync().Result;
                    lstBitacora = JsonConvert.DeserializeObject<List<Bitacora>>(vBitacora);
                }
;            }

             return View(lstBitacora);
        }

        // GET: Bitacora/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Bitacora/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bitacora/Create
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

        // GET: Bitacora/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bitacora/Edit/5
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

        // GET: Bitacora/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bitacora/Delete/5
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