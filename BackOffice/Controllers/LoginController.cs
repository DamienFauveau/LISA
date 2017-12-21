using BackOffice.Models;
using BackOffice.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BackOffice.Controllers
{
    public class LoginController : Controller
    {
        [Route("Connexion")]
        public ActionResult Connexion()
        {
            return View();
        }

        [Route("Connexion")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Connexion([Bind(Include = "Login,Password")] LoginVM connexion)
        {
            string responseString = "";
            if (ModelState.IsValid)
            {
                responseString = HttpClientService.Connexion(connexion);
                if(responseString.Length > 0)
                {
                    TokenVM token = JsonConvert.DeserializeObject<TokenVM>(responseString);
                    Session["token"] = token.Token;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(connexion);
        }
    }
}