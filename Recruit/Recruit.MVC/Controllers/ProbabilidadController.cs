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
    public class ProbabilidadController : Controller
    {
        string apiUrl = "http://localhost:53907/";

        public async Task<IActionResult> Index()
        {
            List<Probabilidad> probabilidadList = new List<Probabilidad>();

            using (var probabilidad = new HttpClient())
            {
                probabilidad.BaseAddress = new Uri(apiUrl);
                probabilidad.DefaultRequestHeaders.Clear();
                probabilidad.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await probabilidad.GetAsync("api/Probabilidad");

                if (res.IsSuccessStatusCode)
                {
                    var probabilidadResult = res.Content.ReadAsStringAsync().Result;
                    probabilidadList = JsonConvert.DeserializeObject<List<Probabilidad>>(probabilidadResult);
                }
            }

            return View(probabilidadList);
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