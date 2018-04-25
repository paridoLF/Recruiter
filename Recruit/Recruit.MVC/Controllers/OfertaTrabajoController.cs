using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Recruit.MVC.Models;

namespace Recruit.MVC.Controllers
{
    public class OfertaTrabajoController : Controller
    {


        string apiUrl = "http://localhost:53908/"; 
        public async Task<IActionResult> Index()
        {
            List<OfertaTrabajoModel> OfertaTrabajoList = new List<OfertaTrabajoModel>();

            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                 HttpResponseMessage res = await client.GetAsync("api/OfertaTrabajo");

                if (res.IsSuccessStatusCode)
                {
                    var ofertatrabajoResult = res.Content.ReadAsStringAsync().Result;
                    OfertaTrabajoList = JsonConvert.DeserializeObject<List<OfertaTrabajoModel>>(ofertatrabajoResult);
                }
            }
            return View(OfertaTrabajoList);
        }

        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Edit()
        {
            return View();
        }


    }
}