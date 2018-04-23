using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Recruit.MVC.Controllers
{
    public class TRecCandidatoController : Controller
    {
        string apUrl = "http://localhost:53917/";
        public IActionResult Index()
        {
            //List<TRecCandidatoController>
            //using (var candidato = new HttpClient())
            //{
            //    candidato.BaseAddress = new Uri("http://localhost:53917/");
            //    candidato.DefaultRequestHeaders.Accept.Clear();
            //    candidato.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));

            //    HttpResponseMessage response = await candidato.GetAsync("api/TRecCandidato");

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var 
            //    }

            //}
               

                return View();
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