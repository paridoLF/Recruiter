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
        public async Task<IActionResult> Detalle(int id)
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

        //LLamar a la vista con los campos vacios para llenarlos y crear el registro en base de datos
        // GET: Bitacora/Create
        public IActionResult Crear()
        {
            return View();
        }

        //Incluye los datos en la base de datos
        // POST: Bitacora/Create
        [HttpPost]
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

        //Obtiene los datos para realizar la modificación de los datos
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


        // POST: Bitacora/Delete/5

        public IActionResult Elimina(int PkBitacora)
        {
            using (var vCliente = new HttpClient())
            {
                vCliente.BaseAddress = new Uri(strApiUrl + "api/Bitacora/");

                var delBitacora = vCliente.DeleteAsync(PkBitacora.ToString());

                if (delBitacora.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }


            }

            return RedirectToAction("Index");
        }
    }
}