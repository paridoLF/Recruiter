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


        string apiUr=""
        public IActionResult Index()
        {



            //using (var client = new HttpClient())

            //{
            //    client.BaseAddress = new Uri("http://llldlddl");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    HttpResponseMessage response = await client.GetAsync("api/");
            //    if (response.IsSuccessStatusCode)
            //    {



            //    }

            //}







            return View();
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