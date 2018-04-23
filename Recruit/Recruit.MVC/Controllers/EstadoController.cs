using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recruit.MVC.Models;

namespace Recruit.MVC.Controllers
{
    public class EstadoController : Controller
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
            ViewData["Message"] = "Edit.";

            return View();
        }

        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

    }
}