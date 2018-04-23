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
using Recruit.MVC.Models;



namespace Recruit.MVC.Controllers
{
    public class ConfiguracionController : Controller
    {

        string apiUrl = "http://localhost:53907/";
        public IActionResult Index(int p)
        {

            //List<ConfiguracionController.>

                return View();
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