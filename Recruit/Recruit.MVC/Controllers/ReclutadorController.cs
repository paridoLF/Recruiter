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
    public class ReclutadorController : Controller
    {

        string apiUrl = "http://localhost:53908/";

        public async Task<IActionResult> Index()
        {
            List<ReclutadorModel> reclutadorList = new List<ReclutadorModel>();

            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Reclutador");

                if (res.IsSuccessStatusCode) {
                    var reclutadorResult = res.Content.ReadAsStringAsync().Result;
                    reclutadorList = JsonConvert.DeserializeObject<List<ReclutadorModel>>(reclutadorResult);

                }
            }
            return View(reclutadorList);
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