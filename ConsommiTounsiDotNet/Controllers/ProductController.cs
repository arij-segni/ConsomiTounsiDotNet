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
           // var _AccessToken = Session[" AccessToken "]);
           // httpClient.DefaultRequestHeaders.Add(" Authorization ", String.Format(" Bearer {0} ", _AccessToken));


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
    }

}