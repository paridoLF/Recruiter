using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Recruit.MVC.Controllers
{
    public class TRecCandidatoController : Controller
    {
        public IActionResult Index()
        {
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