using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Recruit.MVC.Models;
using Newtonsoft.Json;

// controladores empresa.
namespace Recruit.MVC.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult Index()
        {
            List<EmpresaController.>
            var apiURL = "http://http://localhost:53907/";
            using (var Empresa = new HttpClient())
            {

                Empresa.BaseAddress = new Uri(apiURL);
                Empresa.DefaultRequestHeaders.Accept.Clear();
                Empresa.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("apllication/jason"));

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