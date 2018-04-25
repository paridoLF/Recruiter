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
using System.Net.Http.Formatting;



namespace Recruit.MVC.Controllers
{
    public class ConfiguracionController : Controller
    {

        string apiUrl = "http://localhost:53908/";
        public async Task<IActionResult> Index()
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

        public async Task<IActionResult> Edit(int Id)
        {

            ConfiguracionModel configuracionEdit = new ConfiguracionModel();

            using (var configuracion = new HttpClient())
            {

                configuracion.BaseAddress = new Uri(apiUrl);
                configuracion.DefaultRequestHeaders.Clear();
                configuracion.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await configuracion.GetAsync("api/Configuracion/" + Id);



                if (res.IsSuccessStatusCode)
                {
                    var configuracionresult = res.Content.ReadAsStringAsync().Result;

                    configuracionEdit = JsonConvert.DeserializeObject<ConfiguracionModel>(configuracionresult);
                }
            }

            return View(configuracionEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit (ConfiguracionModel configuracion)
        {

            using (var config = new HttpClient())
            {

                config.BaseAddress = new Uri(apiUrl + "api/Configuracion");


                var putEdit = config.PutAsJsonAsync<ConfiguracionModel>("configuracion", configuracion);
                putEdit.Wait();


                if (putEdit.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(configuracion);
        }


    }
}