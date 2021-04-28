using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using ConsommiTounsiDotNet.Models;

namespace ConsommiTounsiDotNet.Controllers
{
    public class ProductController : Controller

    {
        HttpClient httpClient;
        string baseAddress;
        public ProductController()
        {
            baseAddress = " http://localhost:8081/consomiTounsi/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // var _AccessToken = Session[" AccessToken "]); //erreur

            // httpClient.DefaultRequestHeaders.Add(" Authorization ", String.Format(" Bearer {0} ", _AccessToken));//erreur

            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Barear", _AccessToken.ToString());//no err not oki
            // httpClient.DefaultRequestHeaders.Add(" Authorization ", String.Format(" Bearer {0} ", _AccessToken.ToString()));//err
            var _AccessToken = System.Web.HttpContext.Current.Session["access_token"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _AccessToken.ToString());// oki


        }

        // GET: Product
        public ActionResult Index()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress+ "get-all-Products").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var products = tokenResponse.Content.ReadAsAsync<IEnumerable<Product>>().Result;

               // ViewBag.prod = products;
                return View(products);
            }
            else
            {
                return View(new List<Product>());




                // return View();
            }
        }

        // public ActionResult Add()

        // {
        // var tokenResponse = httpClient.GetAsync(baseAddress + "get-all-Products").Result;
        // return ViewBag.prod = "sdfd";
        //@ViewBag.prod
        // }


        [HttpPost]
        //@Url.Action("Product", "addToCart", new { idProd = 1, quantity = 2})
        public ActionResult addToCart( int idProd, FormCollection values)
        {

            var quantity = values["quantity1"];


                using ( httpClient)
                {
                String add =  "addToCart/" + idProd.ToString() +"/"+ quantity.ToString();
                    var postJob = httpClient.PostAsJsonAsync<Product>(baseAddress+ add, null);
                    postJob.Wait();
                    // return View();
                    var postResult = postJob.Result;
                    if (postResult.IsSuccessStatusCode)

                        return RedirectToAction("Index");
                }
        //ModelState.AddModelError(string.Empty, "Server occured errors. Please check with admin!");
         return RedirectToAction("Index");
        //return View();
    }



















        
    }

}