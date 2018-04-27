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
    public class BitacoraController : Controller
    {
        string strApiUrl = "http://localhost:53907/";


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
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Bitacora/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Bitacora p_Bitacora)
        {
            using (var vCliente = new HttpClient())
            {
                vCliente.BaseAddress = new Uri(strApiUrl + "api/Bitacora");

                var putBitacora = vCliente.PostAsJsonAsync<Bitacora>("Bitacora", p_Bitacora);

                putBitacora.Wait();

                if (putBitacora.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(p_Bitacora);
        }

        // GET: Bitacora/Edit/5
        public async Task<IActionResult> Editar(int id)
        {

            Bitacora lstBitacora = new Bitacora();

            using (var vCliente = new HttpClient())
            {
                vCliente.BaseAddress = new Uri(strApiUrl);
                vCliente.DefaultRequestHeaders.Accept.Clear();
                vCliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage hrmResponse = await vCliente.GetAsync("api/Bitacora/" + id);
                if (hrmResponse.IsSuccessStatusCode)
                {
                    var vBitacora = hrmResponse.Content.ReadAsStringAsync().Result;
                    lstBitacora = JsonConvert.DeserializeObject<Bitacora>(vBitacora);
                }
;
            }

            return View(lstBitacora);
        }

        // POST: Bitacora/Edit/5
        [HttpPost]
        public async Task<IActionResult> Editar(Bitacora p_Bitacora)
        {
            using (var vCliente = new HttpClient())
            {
                vCliente.BaseAddress = new Uri(strApiUrl + "api/Bitacora");
                
                var putBitacora = vCliente.PutAsJsonAsync<Bitacora>("Bitacora", p_Bitacora);

                putBitacora.Wait();

                if (putBitacora.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(p_Bitacora);
        }

        // GET: Bitacora/Delete/5
        public IActionResult Elimina(int id)
        {
            return View();
        }

        // POST: Bitacora/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Elimina(int id, IFormCollection collection)
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