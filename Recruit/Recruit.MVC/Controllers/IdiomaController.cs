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
    public class IdiomaController : Controller
    {
        string apiURL = "http://localhost:53908/";

        public async Task<IActionResult> Index()
        {
            List<Idioma> idiomaList = new List<Idioma>();

            using (var idioma = new HttpClient())
            {
                idioma.BaseAddress = new Uri(apiURL);
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