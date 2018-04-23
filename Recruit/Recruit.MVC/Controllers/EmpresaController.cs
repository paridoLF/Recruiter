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
        string apiURL = "http://http://localhost:53907/";

        public async Task<IActionResult> Index()
        {
            List<EmpresaModel> EmpresaList = new List<EmpresaModel>();

            using (var Empresa = new HttpClient())
            {

                Empresa.BaseAddress = new Uri(apiURL);
                Empresa.DefaultRequestHeaders.Accept.Clear();
                Empresa.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("apllication/jason"));

                HttpResponseMessage res = await Empresa.GetAsync("api/Empresa");
                if (res.IsSuccessStatusCode)
                {
                    var Empresaresult = res.Content.ReadAsStringAsync().Result;
                    EmpresaList = JsonConvert.DeserializeObject<List<EmpresaModel>>(Empresaresult);
                }

                return View(EmpresaList);
            }
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