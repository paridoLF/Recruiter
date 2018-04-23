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

        string apiUrl = "http://localhost:5555/";

        public IActionResult Index()
        {
           
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