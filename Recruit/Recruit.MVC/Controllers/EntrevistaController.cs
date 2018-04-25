using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Recruit.MVC.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Recruit.MVC.Controllers
{
    public class EntrevistaController : Controller
    {
        string apiUrl = "http://localhost:53907/";

        public async Task<IActionResult> Index()
        {
            List<Entrevista> entrevistaList = new List<Entrevista>();

            using (var entrevista = new HttpClient())
            {
                entrevista.BaseAddress = new Uri(apiUrl);
                entrevista.DefaultRequestHeaders.Clear();
                entrevista.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await entrevista.GetAsync("api/Entrevista");

                if (res.IsSuccessStatusCode)
                {
                    var entrevistaResult = res.Content.ReadAsStringAsync().Result;
                    entrevistaList = JsonConvert.DeserializeObject<List<Entrevista>>(entrevistaResult);
                }
            }

            return View(entrevistaList);
        }

        public IActionResult Create()
        {
            ViewData["Message"] = "Create";

            return View();
        }

        public IActionResult Edit()
        {
            ViewData["Message"] = "Edit";

            return View();
        }
    }
}