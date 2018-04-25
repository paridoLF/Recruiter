using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Recruit.MVC.Models;
using Newtonsoft.Json;


namespace Recruit.MVC.Controllers
{
    public class ConfiguracionController : Controller
    {

        string apiUrl = "http://localhost:53907/";
        public  async Task<IActionResult> Index()
        {

            List<ConfiguracionModel> configuracionList = new List<ConfiguracionModel>();

            using (var configuracion = new HttpClient()) {

                configuracion.BaseAddress = new Uri(apiUrl);
                configuracion.DefaultRequestHeaders.Clear();
                configuracion.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await configuracion.GetAsync("api/Configuracion");

                

                if (res.IsSuccessStatusCode) {
                    var configuracionresult = res.Content.ReadAsStringAsync().Result;

                    configuracionList = JsonConvert.DeserializeObject<List<ConfiguracionModel>>(configuracionresult);
                }
            }


                return View(configuracionList);
        }   

        public IActionResult Create(int p)
        {
            return View();
        }

        public IActionResult Edit(int p)
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}