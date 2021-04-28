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
               baseAddress = " http://localhost:8081/consomiTounsi/";
               httpClient = new HttpClient();
               httpClient.BaseAddress = new Uri(baseAddress);
               httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
              // var _AccessToken = Session[" AccessToken "]);
              // httpClient.DefaultRequestHeaders.Add(" Authorization ", String.Format(" Bearer {0} ", _AccessToken));


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





        public ActionResult getUsr(int id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "user/"+id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var user1 = tokenResponse.Content.ReadAsAsync<Users>().Result;
                return View(user1);
            }
            else
            {
                return View(new Users("new" , "new"));
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


