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
    public class TRecCandidatoController : Controller
    {
        string apUrl = "http://localhost:53908/";
        public async Task<IActionResult> Index()
        {
            List<TRecCandidatoModel> candidatoList = new List<TRecCandidatoModel>();

            using (var candidato = new HttpClient())
            {
                candidato.BaseAddress = new Uri(apUrl);
                candidato.DefaultRequestHeaders.Clear();
                candidato.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage res = await candidato.GetAsync("api/TRecCandidato");
                //await es asincronica por eso se cambia el formato de la funcion de public IActionResult Index() 
                //a public async Task<IActionResult> Index()

                if (res.IsSuccessStatusCode)
                {
                    var candidatoResult = res.Content.ReadAsStringAsync().Result;

                    candidatoList = JsonConvert.DeserializeObject<List<TRecCandidatoModel>>(candidatoResult);

                }

            }

                return View(candidatoList);
        }

        public IActionResult Create()
        {
            //ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Edit() 
        {
            //ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Delete()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}