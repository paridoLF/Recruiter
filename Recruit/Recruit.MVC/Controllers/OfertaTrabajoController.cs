using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Recruit.MVC.Models;
using System.Net.Http.Formatting;

namespace Recruit.MVC.Controllers
{
    public class OfertaTrabajoController : Controller
    {


        string apiUrl = "http://localhost:53908/";
        public async Task<IActionResult> Index()
        {
            List<OfertaTrabajoModel> OfertaTrabajoList = new List<OfertaTrabajoModel>();

            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/OfertaTrabajo");

                if (res.IsSuccessStatusCode)
                {
                    var ofertatrabajoResult = res.Content.ReadAsStringAsync().Result;
                    OfertaTrabajoList = JsonConvert.DeserializeObject<List<OfertaTrabajoModel>>(ofertatrabajoResult);
                }
            }
            return View(OfertaTrabajoList);
        }


        public IActionResult Create()
        {
            return View();
        }

        

        [HttpPost]
        public async Task<IActionResult> Create(OfertaTrabajoModel OfertaTrabajo)
        {


            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(apiUrl + "api/OfertaTrabajo");

                var postOfertaTrabajo = client.PostAsJsonAsync<OfertaTrabajoModel>("OfertaTrabajo", OfertaTrabajo);
                postOfertaTrabajo.Wait();

                if (postOfertaTrabajo.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(OfertaTrabajo);
        }


   
        public async Task<IActionResult> Edit(int id)
        {

            OfertaTrabajoModel OfertaTrabajoEdit = new OfertaTrabajoModel();

            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/OfertaTrabajo/"+ id);

                if (res.IsSuccessStatusCode)
                {
                    var ofertatrabajoResult = res.Content.ReadAsStringAsync().Result;
                    OfertaTrabajoEdit = JsonConvert.DeserializeObject<OfertaTrabajoModel>(ofertatrabajoResult);
                }
            }
            return View(OfertaTrabajoEdit);

        }
       

        [HttpPost]
       public async Task<IActionResult> Edit(OfertaTrabajoModel OfertaTrabajo)
        {


            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(apiUrl + "api/OfertaTrabajo");

                var putOfertaTrabajo = client.PutAsJsonAsync<OfertaTrabajoModel>("OfertaTrabajo", OfertaTrabajo);
                putOfertaTrabajo.Wait();           

                if (putOfertaTrabajo.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(OfertaTrabajo);

        }


        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(apiUrl + "api/OfertaTrabajo/");

                var deleteOfertaTrabajo = client.DeleteAsync(id.ToString());
                deleteOfertaTrabajo.Wait();

                if (deleteOfertaTrabajo.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Details(int id)
        {

            OfertaTrabajoModel OfertaTrabajoEdit = new OfertaTrabajoModel();

            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/OfertaTrabajo/" + id);

                if (res.IsSuccessStatusCode)
                {
                    var ofertatrabajoResult = res.Content.ReadAsStringAsync().Result;
                    OfertaTrabajoEdit = JsonConvert.DeserializeObject<OfertaTrabajoModel>(ofertatrabajoResult);
                }
            }
            return View(OfertaTrabajoEdit);

        }


    }
}