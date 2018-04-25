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
        string apiURL = "http://localhost:53908/";

        public async Task<IActionResult> Index()
        {
            List<Estado> estadoList = new List<Estado>();

            using (var estado = new HttpClient())
            {
                estado.BaseAddress = new Uri(apiURL);
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

        public IActionResult Edit()
        {
            ViewData["Message"] = "Edit.";

            return View();
        }

        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

    }
}