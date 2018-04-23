﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recruit.MVC.Models;

namespace Recruit.MVC.Controllers
{
    public class ConfiguracionController : Controller
    {
        public IActionResult Index(int p)
        {
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