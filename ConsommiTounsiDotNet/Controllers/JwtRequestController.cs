using ConsommiTounsiDotNet.Models;
using System;
using System.Collections.Generic;
//using System.Net.Http;
using System.Web.Mvc;


//using System.Net.Http;
using System.Net.Http.Headers;

//using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
//using Microsoft.AspNetCore.Http;

//using Microsoft.AspNetCore.Http;
namespace ConsommiTounsiDotNet.Controllers
{
    public class JwtRequestController : Controller


    {
        HttpClient httpClient;
        string baseAddress;


        // GET: JwtRequest
        public ActionResult Login()


        {


            return View();
        }


        /* public static void SetString(this ISession session, string key, string value)
         {
             session.Set(key, System.Text.Encoding.UTF8.GetBytes(value));
         }*/

        /*  public static string GetString(this ISession session, string key)
          {
              var data = session.Set(key);
              if (data == null)
              {
                  return null;
              }
              return System.Text.Encoding.UTF8.GetString(data);
          }*/

        // public ActionResult showBarerr(JwtRequest jwt)
        public async Task<ActionResult> showBarerr(JwtRequest jwt)


        {
            using (var httpClient = new HttpClient())
            {

                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(jwt), System.Text.Encoding.UTF8, "application/json");
                using (var response1 = await httpClient.PostAsync("http://localhost:8082/authenticate", stringContent))
                {
                    String myTok = await response1.Content.ReadAsStringAsync();
                    if (myTok == "Invalid credentials")
                    {
                        ViewBag.mssg = "incorrct usr";
                    }

                    HttpContext.Session.Add("authenticate", myTok);

                    var _AccessToken = System.Web.HttpContext.Current.Session["authenticate"];//oki

                    ViewBag.bareer = stringContent;
                    ViewBag.bareerConsumedResps = stringContent;

                    ViewBag.bareerConsumed = myTok;
                    ViewBag.bareeSession = _AccessToken;

                }
            }





            /// httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri(baseAddress);
            /// httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            /// var resp = httpClient.PostAsJsonAsync<JwtRequest>("http://localhost:8081/consomiTounsi/authenticate", jwt);

            //HttpResponseMessage result = httpClient.PostAsync(getTokenUrl, content).Result;

            // string resultContent = resp.Content.ReadAsStringAsync().Result;

            // var token = JsonConvert.DeserializeObject<JwtRequest>(resultContent);

            //httpClient.DefaultRequestHeaders.Add(" Authorization ", String.Format(" Bearer {0} ", resp));

            //var str = GetTokenDetails(jwt.username, jwt.password);

            // var _AccessToken = Session([" AccessToken "]);
            //var token = JsonConvert.DeserializeObject<Token>(resp);
            //ViewBag.bareer = resp.ToString();
            //ViewData["bareer"] = str;




            /*******/
            //var getTokenUrl = string.Format(ApiEndPoints.AuthorisationTokenEndpoint.Post.Token, System.Configuration.ConfigurationManager.AppSettings["http://localhost:8081/consomiTounsi/authenticate"]);

            ///      using (HttpClient httpClient = new HttpClient())
            ///      {
            /*using (var client = new HttpClient())
            {*/
            ///              var content = new Dictionary<string, string>
            /*            {
                            {"grant_type", "password"},
                            {"username", jwt.username},
                            {"password", jwt.password},
                        };
            */

            /*    HttpContent content1 = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", jwt.username),
                new KeyValuePair<string, string>("password", jwt.password)
            });*/

            // HttpResponseMessage result = httpClient.PostAsync("http://localhost:8081/consomiTounsi/authenticate", content).Result;
            /*
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                            var resp = httpClient.PostAsJsonAsync<Dictionary<string, string>>("http://localhost:8081/consomiTounsi/authenticate", content).Result;
                                var resultContent = resp.Content.ReadAsStringAsync().Result;
            */
            //    var jwtResponse = JsonConvert.DeserializeObject<JwtResponse>(resultContent);
            //httpClient.DefaultRequestHeaders.Add(" Authorization ", String.Format(" Bearer {0} ", jwtResponse.jwttoken)); //ERREUR
            // httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=jwtResponse.jwttoken"); //NULL
            //  httpClient.DefaultRequestHeaders.Authorization =new AuthenticationHeaderValue(jwtResponse.jwttoken);//err

            //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=jwtResponse.jwttoken");

            ///               HttpContext.Session.Add("access_token", resultContent);


            /*request.ContentType = "application/json";
            request.Method = "POST";
            request.Headers.Set("Authorization", string.Format("Bearer {0}", tk));*/
            // var authenticationHeaderValue = new AuthenticationHeaderValue("Bearer", jwtResponse.jwttoken);


            //HttpContext.Session.addString("access_token", resultContent);
            ///               var _AccessToken = System.Web.HttpContext.Current.Session["access_token"];
            ///               httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Barear", _AccessToken.ToString());
            //httpClient.DefaultRequestHeaders.Add(" Authorization ", String.Format(" Bearer {0} ", jwtResponse.jwttoken));

            // var _AccessToken2 = Session([" AccessToken "]);

            // ViewBag.bareer = _AccessToken;
            //  ViewBag.bareerConsumedResps = "";

            //ViewBag.bareerConsumed = resultContent;
            //ViewBag.bareeSession = _AccessToken;




            ///         }



            return View();
        }


        /* static Dictionary<string, string> GetTokenDetails(string userName, string password)
         {
             Dictionary<string, string> tokenDetails = null;
             try
             {
                 using (var client = new HttpClient())
                 {
                     var login = new Dictionary<string, string>
                    {
                        {"grant_type", "password"},
                        {"username", userName},
                        {"password", password},
                    };

                     var resp = client.PostAsJsonAsync<Dictionary<string, string>>("http://localhost:8081/consomiTounsi/authenticate", login);

                    // var resp = client.PostAsync("http://localhost:8081/consomiTounsi/authenticate", new FormUrlEncodedContent(login));
                     resp.Wait(TimeSpan.FromSeconds(10));

                     if (resp.IsCompleted)
                     {
                         if (resp.Result.Content.ReadAsStringAsync().Result.Contains("access_token"))
                         {
                             tokenDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(resp.Result.Content.ReadAsStringAsync().Result);
                         }
                     }

                     *//*                   string resultContent = resp.Content.ReadAsStringAsync().Result;

                                        var token = JsonConvert.DeserializeObject<Token>(resultContent);*//*




                 }
             }
             catch (Exception ex)
             {

             }
             return tokenDetails;
         }*/





        /*   static string PostData(string token, List<KeyValuePair<string, string>> lsPostContent)
           {
               string response = String.Empty;
               try
               {
                   using (var client = new HttpClient())
                   {
                       FormUrlEncodedContent cont = new FormUrlEncodedContent(lsPostContent);
                       client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                       var resp = client.PostAsync("https://localhost:61086/api/<your API controller>/", cont);

                       resp.Wait(TimeSpan.FromSeconds(10));

                       if (resp.IsCompleted)
                       {
                           if (resp.Result.StatusCode == HttpStatusCode.Unauthorized)
                           {
                               Console.WriteLine("Authorization failed. Token expired or invalid.");
                           }
                           else
                           {
                               response = resp.Result.Content.ReadAsStringAsync().Result;
                               Console.WriteLine(response);
                           }
                       }
                   }
               }
               catch (Exception ex)
               {

               }
               return response;
           }*/



    }
}
