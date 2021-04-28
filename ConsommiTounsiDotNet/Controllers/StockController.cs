using ConsommiTounsiDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsiDotNet.Controllers
{
    public class StockController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public StockController()
        {
            baseAddress = "http://localhost:8082/consomitounsi/servlet";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var _AccessToken = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJhcmlqIiwiZXhwIjoxNjE5NjAzNjk0LCJpYXQiOjE2MTk1ODU2OTR9.2dMzzeV0BqoBkXMLWyliEde93B-tuooGDb0ei5kKoSacvcnSntgGj92wqZCXlcfo8Qh6mQyLTzKNdTy5gjBkDA";
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
        }
        // GET: Stock
        public ActionResult Index()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "/getAllStocks").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var stocks = tokenResponse.Content.ReadAsAsync<IEnumerable<Stock>>().Result;
                return View(stocks);
            }
            else
            {
                return View(new List<Stock>());
            }
        }

        // GET: Stock/Details/5
        public ActionResult Details(int idStock)
        {
            return View();
        }

        // GET: Stock/Create
        public ActionResult Create()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "/addStock").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var stock = tokenResponse.Content.ReadAsAsync<Stock>().Result;
                return View(stock);
            }
            else
            {
                return View(new Stock());
            }
        }
        public ViewResult Createt() => View();

        // POST: Stock/Create
        [HttpPost]
        public ActionResult Create(Stock s)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<Stock>(baseAddress + "/addStock",
                    s).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                return RedirectToAction("Index");


            }
            catch
            {
                return View();
            }
        }

        // GET: Stock/Edit/5
        public ActionResult Edit(int idStock)
        {
            var APIResponse = httpClient.GetAsync(baseAddress + "/getStockById/" + idStock).Result;
            if (APIResponse.IsSuccessStatusCode)
            {
                var stock = APIResponse.Content.ReadAsAsync<Stock>().Result;
                return View(stock);
            }
            else
            {
                return View(new Stock());
            }
        }

        // POST: Stock/Edit/5
        [HttpPost]
        public ActionResult Edit(Stock stock)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Stock>(baseAddress + "/updateStock", stock).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Stock/Delete/5
        public ActionResult Delete(int idStock)
        {
            var APIResponse = httpClient.DeleteAsync(baseAddress + "/deleteStock/" + idStock).Result;
            if (APIResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new Stock());
            }
        }

        // POST: Stock/Delete/5
        [HttpPost]
        public ActionResult Delete(int idStock, Stock stock)
        {
            try
            {
                var APIResponse = httpClient.DeleteAsync(baseAddress + "/deleteStock/" + idStock).Result;
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
        public ActionResult MissingProduct()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "/missingProduct").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var stocks = tokenResponse.Content.ReadAsAsync<Stock>().Result;
                return View(stocks);
            }
            else
            {
                return View(new List<Stock>());
            }
            //return View();
        }

    }
}
