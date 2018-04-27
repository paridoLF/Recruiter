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
    public class IdiomaController : Controller
    {
        string apiUrl = "http://localhost:53908/";

        public async Task<IActionResult> Index()
        {
            List<Idioma> idiomaList = new List<Idioma>();

            using (var idioma = new HttpClient())
            {
                idioma.BaseAddress = new Uri(apiUrl);
                idioma.DefaultRequestHeaders.Accept.Clear();
                idioma.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await idioma.GetAsync("api/Idioma");

                if(res.IsSuccessStatusCode)
                {
                    var idiomaResult = res.Content.ReadAsStringAsync().Result;

                    idiomaList = JsonConvert.DeserializeObject<List<Idioma>>(idiomaResult);
                }
            }

               return View(idiomaList);
        }

        public IActionResult Create()
        {
            ViewData["Message"] = "Create";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Idioma idioma)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl + "api/Idioma");

                var putIdioma = client.PostAsJsonAsync<Idioma>("Idioma", idioma);
                putIdioma.Wait();

                if (putIdioma.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
            }

            return View(idioma);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Idioma idiomaEdit = new Idioma();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Idioma/" + id);

                if (res.IsSuccessStatusCode)
                {
                    var idiomaResult = res.Content.ReadAsStringAsync().Result;
                    idiomaEdit = JsonConvert.DeserializeObject<Idioma>(idiomaResult);

                }
            }
            return View(idiomaEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Idioma idioma)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl + "api/Idioma");

                var putIdioma = client.PutAsJsonAsync<Idioma>("Idioma", idioma);
                putIdioma.Wait();

                if (putIdioma.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
            }

            return View(idioma);
        }

        public async Task<IActionResult> Details(int id)
        {
            Idioma idiomaEdit = new Idioma();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Idioma/" + id);

                if (res.IsSuccessStatusCode)
                {
                    var idiomaResult = res.Content.ReadAsStringAsync().Result;
                    idiomaEdit = JsonConvert.DeserializeObject<Idioma>(idiomaResult);

                }
            }
            return View(idiomaEdit);
        }
    }
}