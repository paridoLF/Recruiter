using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Recruit.MVC.Models;


namespace Recruit.MVC.Controllers
{
    public class TRecCandidatoController : Controller
    {

        string apiUrl = "http://localhost:53908/";
        public async Task<IActionResult> Index()
        {
            List<TRecCandidatoModel> candidatoList = new List<TRecCandidatoModel>();

            using (var candidato = new HttpClient())
            {
                candidato.BaseAddress = new Uri(apiUrl);
                candidato.DefaultRequestHeaders.Clear();
                candidato.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage res = await candidato.GetAsync("api/TRecCandidato");
                //await es asincronica por eso se cambia el formato de la funcion de public IActionResult Index() 
                //a public async Task<IActionResult> Index()

                if (res.IsSuccessStatusCode)
                {
                    var candidatoResult = res.Content.ReadAsStringAsync().Result;

                    candidatoList = JsonConvert.DeserializeObject<List<TRecCandidatoModel>>(candidatoResult);

                }

            }

            return View(candidatoList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TRecCandidatoModel candidatoModel)
        {
            using (var candidato = new HttpClient())
            {

                candidato.BaseAddress = new Uri(apiUrl + "api/TRecCandidato");

                var putCandidato = candidato.PostAsJsonAsync<TRecCandidatoModel>("TRecCandidato", candidatoModel);
                putCandidato.Wait();

                if (putCandidato.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }

            return View(candidatoModel);
        }

   
        public async Task<IActionResult> Edit(int id)
        {
            //ViewData["Message"] = "Your contact page.";

            TRecCandidatoModel candidatoEdit = new TRecCandidatoModel();

            using (var candidato = new HttpClient())
            {
                candidato.BaseAddress = new Uri(apiUrl);
                candidato.DefaultRequestHeaders.Clear();
                candidato.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage res = await candidato.GetAsync("api/TRecCandidato/" + id);
                //await es asincronica por eso se cambia el formato de la funcion de public IActionResult Index() 
                //a public async Task<IActionResult> Index()

                if (res.IsSuccessStatusCode)
                {
                    var candidatoResult = res.Content.ReadAsStringAsync().Result;

                    candidatoEdit = JsonConvert.DeserializeObject<TRecCandidatoModel>(candidatoResult);

                }

            }
            return View(candidatoEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TRecCandidatoModel candidatoModel)
        {

            using (var candidato = new HttpClient())
            {

                candidato.BaseAddress = new Uri(apiUrl + "api/TRecCandidato");

                var putCandidato = candidato.PutAsJsonAsync<TRecCandidatoModel>("TRecCandidato", candidatoModel);
                putCandidato.Wait();

                if (putCandidato.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }

            return View(candidatoModel);
        }


        public ActionResult Delete(int id)
        {
            using (var candidato = new HttpClient())
            {

                candidato.BaseAddress = new Uri(apiUrl + "api/TRecCandidato/");

                var delCandidato = candidato.DeleteAsync(id.ToString());
                delCandidato.Wait();

                if (delCandidato.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return RedirectToAction("Index");
        }
    }
}