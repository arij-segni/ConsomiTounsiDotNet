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
    public class UsersController : Controller
    {

        HttpClient httpClient;
        string baseAddress;


        public UsersController()
        {
            baseAddress = " http://localhost:8082/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // var _AccessToken = Session[" AccessToken "]);
            // httpClient.DefaultRequestHeaders.Add(" Authorization ", String.Format(" Bearer {0} ", _AccessToken));


            var _AccessToken = System.Web.HttpContext.Current.Session["authenticate"];
            if (_AccessToken == null)
            {
                return;

            }
            else
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( _AccessToken.ToString());// oki
            }

        }

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }




        //( "nabil", "chemkhi", "dfdsf", "hsf", "sdfsdf", "123", Role.Customer );
        //new Users {1 , "nabil" , "chemkhi" , "dfdsf" , "hsf" , "sdfsdf" , "123" , Role.Customer };
        //user.Name = "nnn";
        // [HttpPost]


        // public Users user3 = new Users("nabil", "123");
        //[HttpPost]
        public ActionResult register()

        {

            return View();

        }


        [HttpPost]
        public ActionResult create(Users user)

        {


            //var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(user); ;

            try
            {

                var APIResponse = httpClient.PostAsJsonAsync<Users>(baseAddress + "register", user); //authenticate//register
                                                                                                     //.ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                // return 
                // return RedirectToAction("getUsr" + user.id);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();

            }
        }

        public ActionResult addUser()
        {




            return View();
        }


        [HttpPost]
        public ActionResult addUser2(Users customer)
        {
            using (httpClient)
            {

                var postJob = httpClient.PostAsJsonAsync<Users>("user/add", customer);
                postJob.Wait();
                // return View();
                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)

                    return RedirectToAction("getAllUsers");
            }
            //ModelState.AddModelError(string.Empty, "Server occured errors. Please check with admin!");
            return View(customer);
        }











        public ActionResult getUsr(int id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "user/get/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var user1 = tokenResponse.Content.ReadAsAsync<Users>().Result;
                return View(user1);
            }
            else
            {
                return View(new Users("new", "new"));
            }

        }


        public ActionResult getAllUsers()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "user/all").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var users = tokenResponse.Content.ReadAsAsync<IEnumerable<Users>>().Result;

                // 
                return View(users);
            }
            else
            {
                return View(new List<Users>());




                // return View();
            }
        }












        /*     public ActionResult Delete(int id)
             {
                 using (httpClient)
                 {


                     //HTTP POST
                     var deleteTask = httpClient.DeleteAsync("user/delete/" + id.ToString());
                     deleteTask.Wait();

                     var result = deleteTask.Result;
                     if (result.IsSuccessStatusCode)
                     {

                         return RedirectToAction("getAllUsers");

                     }
                     return RedirectToAction("getAllUsers");

                 }

             }
     */
        public ActionResult Delete5(int id)
        {
            /* using (var client = new HttpClient())
             {
                 //client.BaseAddress = new Uri(" http://localhost:8081/consomiTounsi/");

                 var _AccessToken = System.Web.HttpContext.Current.Session["access_token"];
                 if (_AccessToken == null)
                 {
                     return RedirectToAction("getAllUsers"); ;

                 }
                 else
                 {
                     client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _AccessToken.ToString());// oki
                 }
 */
            using (httpClient)
            {

                //HTTP POST
                var deleteTask = httpClient.DeleteAsync("user/delete/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("getAllUsers");

                }
                return RedirectToAction("getAllUsers");

            }

        }






        [HttpPost]
        /*    public ActionResult Delete2(int id)
            {

                using (httpClient)
                {


                    //HTTP POST
                    var deleteTask = httpClient.DeleteAsync("user/delete/" + id.ToString());
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        return RedirectToAction("getAllUsers");

                    }
                    return RedirectToAction("getAllUsers");

                }

            }
    */



        /*   [HttpPost]
           public ActionResult Edit(int id)
           {
               return View();
           }
   */


        /*     // POST: Driver/Edit/5
             [HttpPost]
             public ActionResult Edit2(Users user,int id)
             {
                 using (httpClient)
                 {
                     //client.BaseAddress = new Uri("http://localhost:8085/");


                     //HTTP POST
                     var putTask = httpClient.PutAsJsonAsync<Users>("user/update2/" + id.ToString(), user);
                     putTask.Wait();

                     var result = putTask.Result;
                     if (result.IsSuccessStatusCode)
                     {

                         return View();

                         //return RedirectToAction("getAllUsers");

                     }
                     return View();

                 }

             }*/


        /*        [HttpPost]
            public ActionResult Edit3(Users user)
            {
                using (httpClient)
                {



                    //HTTP POST
                    var putTask = httpClient.PutAsJsonAsync<Users>("user/update3" , user);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        return View();

                        //return RedirectToAction("getAllUsers");

                    }
                    return View();

                }

            }*/




        public ActionResult Edit5(int id)
        {
            Users pub = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" http://localhost:8081/consomiTounsi/");

                var _AccessToken = System.Web.HttpContext.Current.Session["access_token"];
                if (_AccessToken == null)
                {
                    return RedirectToAction("getAllUsers"); ;

                }
                else
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _AccessToken.ToString());// oki
                }
                /*using (httpClient)
                {*/

                //HTTP GET

                var responseTask = client.GetAsync("user/get/" + id.ToString());
                responseTask.Wait();



                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Users>();
                    readTask.Wait();

                    pub = readTask.Result;
                }
            }

            return View(pub);
        }

        // POST: Driver/Edit/5
        [HttpPost]
        public ActionResult Edit5(Users pub, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" http://localhost:8081/consomiTounsi/");

                var _AccessToken = System.Web.HttpContext.Current.Session["access_token"];
                if (_AccessToken == null)
                {
                    return RedirectToAction("getAllUsers"); ;

                }
                else
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _AccessToken.ToString());// oki
                }

                /* using (httpClient)
                 {*/

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Users>("user/update/" + id.ToString(), pub);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("getAllUsers");

                }
                // return View(pub);
                return RedirectToAction("getAllUsers");

            }

        }






        public ActionResult Edit6(int id)
        {
            Users pub = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" http://localhost:8081/consomiTounsi/");

                var _AccessToken = System.Web.HttpContext.Current.Session["access_token"];
                if (_AccessToken == null)
                {
                    return RedirectToAction("getAllUsers"); ;

                }
                else
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _AccessToken.ToString());// oki
                }
                /*using (httpClient)
                {*/

                //HTTP GET

                var responseTask = client.GetAsync("user/get/" + id.ToString());
                responseTask.Wait();



                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Users>();
                    readTask.Wait();

                    pub = readTask.Result;
                }
            }

            return View(pub);
        }

        // POST: Driver/Edit/5
        [HttpPost]
        public ActionResult Edit6(Users pub, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" http://localhost:8081/consomiTounsi/");

                var _AccessToken = System.Web.HttpContext.Current.Session["access_token"];
                if (_AccessToken == null)
                {
                    return RedirectToAction("getAllUsers"); ;

                }
                else
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _AccessToken.ToString());// oki
                }

                /* using (httpClient)
                 {*/

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Users>("user/update/" + id.ToString(), pub);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("getAllUsers");

                }
                return View(pub);
                //return RedirectToAction("getAllUsers");

            }

        }







    }

}





/*       // POST: /Account/Register
       [HttpPost]
       [AllowAnonymous]
       [ValidateAntiForgeryToken]
       public async Task<ActionResult> Register(Users model)
       {
           if (ModelState.IsValid)
           {
               var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
               var result = await UserManager.CreateAsync(user, model.Password);
               if (result.Succeeded)
               {
                   await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                   // Pour plus d'informations sur l'activation de la confirmation de compte et de la réinitialisation de mot de passe, visitez https://go.microsoft.com/fwlink/?LinkID=320771
                   // Envoyer un message électronique avec ce lien
                   // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                   // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                   // await UserManager.SendEmailAsync(user.Id, "Confirmez votre compte", "Confirmez votre compte en cliquant <a href=\"" + callbackUrl + "\">ici</a>");

                   return RedirectToAction("Index", "Home");
               }
               AddErrors(result);
           }

           // Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
           return View(model);
       }*/