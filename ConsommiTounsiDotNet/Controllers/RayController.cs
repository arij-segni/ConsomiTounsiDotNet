using ConsommiTounsiDotNet.Models;
using ConsommiTounsiDotNet.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsiDotNet.Controllers
{
    public class RayController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public RayController()
        {
                baseAddress = "http://localhost:8082/consomitounsi/servlet";
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseAddress);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var _AccessToken = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJhcmlqIiwiZXhwIjoxNjE5NjAzNjk0LCJpYXQiOjE2MTk1ODU2OTR9.2dMzzeV0BqoBkXMLWyliEde93B-tuooGDb0ei5kKoSacvcnSntgGj92wqZCXlcfo8Qh6mQyLTzKNdTy5gjBkDA";
                httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
        }

        // GET: Ray
        public ActionResult Index()
        {

            var tokenResponse = httpClient.GetAsync(baseAddress + "/retrieve-all-rays").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var rays = tokenResponse.Content.ReadAsAsync<IEnumerable<Ray>>().Result;
                return View(rays);
            }
            else
            {
                return View(new List<Ray>());
            }




            //return View(rayService.GetAll());

        }
        // GET: Ray/Details/5
        public ActionResult Details(long idRay)
        {
            return View();
        }
        // GET: Ray/Create
        
        public ActionResult Create()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "/addRay").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var ray = tokenResponse.Content.ReadAsAsync<Ray>().Result;
                return View(ray);
            }
            else
            {
                return View(new Ray());
            }
        }
        public ViewResult Createt() => View();

        // POST: Ray/Create
        [HttpPost]
        public ActionResult Create(Ray r)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<Ray>(baseAddress + "/addRay",
                    r).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                return RedirectToAction("Index");


            }
            catch{
                return View();
            }
            
     
        }

        // GET: Ray/Edit/5
       
        public ActionResult Edit(long idRay)
        {
            var APIResponse = httpClient.GetAsync(baseAddress + "/getRayById/"+idRay).Result;
            if (APIResponse.IsSuccessStatusCode)
            {
                var ray = APIResponse.Content.ReadAsAsync<Ray>().Result;
                return View(ray);
            }
            else
            {
                return View(new Ray());
            }

        }

        // POST: Ray/Edit/5
        [HttpPost]
        public ActionResult Edit(Ray ray)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Ray>(baseAddress + "/updateRay", ray).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ray/Delete/5
        public ActionResult Delete(long idRay)
        {
            var APIResponse = httpClient.DeleteAsync(baseAddress + "/deleteRay/" +idRay).Result;
            if (APIResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new Ray());
            }
        }

        // POST: Ray/Delete/5
        [HttpPost]
        public ActionResult Delete(long idRay, Ray ray)
        {
            try
            {
                var APIResponse = httpClient.DeleteAsync(baseAddress + "/deleteRay/" +idRay).Result;
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
