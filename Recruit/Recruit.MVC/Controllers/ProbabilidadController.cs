using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Recruit.MVC.Controllers
{
    public class ProbabilidadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewData["Message"] = "Create";

            return View();
        }

        public IActionResult Edit()
        {
            ViewData["Message"] = "Edit";

            return View();
        }
    }
}