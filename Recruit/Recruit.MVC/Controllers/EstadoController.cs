using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Recruit.MVC.Models;

namespace Recruit.MVC.Controllers
{
    public class EstadoController : Controller
    {
        string apiUrl = "http://localhost:53908/";

        public async Task<IActionResult> Index()
        {
            List<Estado> estadoList = new List<Estado>();

            using (var estado = new HttpClient())
            {
                estado.BaseAddress = new Uri(apiUrl);
                estado.DefaultRequestHeaders.Clear();
                estado.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await estado.GetAsync("api/Estado");

                if (res.IsSuccessStatusCode)
                {
                    var estadoResult = res.Content.ReadAsStringAsync().Result;
                    estadoList = JsonConvert.DeserializeObject<List<Estado>>(estadoResult);
                }
            }

            return View(estadoList);
        }

        public IActionResult Create()
        {
            ViewData["Message"] = "Create";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Estado estado)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl + "api/Estado");

                var putEstado = client.PostAsJsonAsync<Estado>("Estado", estado);
                putEstado.Wait();

                if (putEstado.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
            }

            return View(estado);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Estado estadoEdit = new Estado();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Estado/" + id);

                if (res.IsSuccessStatusCode)
                {
                    var estadoResult = res.Content.ReadAsStringAsync().Result;
                    estadoEdit = JsonConvert.DeserializeObject<Estado>(estadoResult);

                }
            }
            return View(estadoEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Estado estado)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl + "api/Estado");

                var putEstado = client.PutAsJsonAsync<Estado>("Estado", estado);
                putEstado.Wait();

                if (putEstado.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
            }

            return View(estado);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl + "api/Estado/");

                var deleteEstado = client.DeleteAsync(id.ToString());
                deleteEstado.Wait();

                if (deleteEstado.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
            }

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Details(int id)
        {
            Estado estadoEdit = new Estado();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Estado/" + id);

                if (res.IsSuccessStatusCode)
                {
                    var estadoResult = res.Content.ReadAsStringAsync().Result;
                    estadoEdit = JsonConvert.DeserializeObject<Estado>(estadoResult);

                }
            }
            return View(estadoEdit);
        }
    }
}