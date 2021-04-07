using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MyShelf.Areas.Seguranca.Models;
using MyShelf.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MyShelf.Areas.Seguranca.Controllers
{
    public class AccountController : Controller
    {
        // Propriedades
        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private GerenciadorUsuario UserManager
        {
            get
            {
                return
          HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }
        // Metodos
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Usuario user = UserManager.Find(details.Nome, details.Senha);
                if (user == null)
                {
                    ModelState.AddModelError("", "Nome ou senha inválido(s).");
                }
                else
                {
                    ClaimsIdentity ident = UserManager.CreateIdentity(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties
                    { IsPersistent = false }, ident);
                    if (returnUrl == null)
                        returnUrl = Url.Action("Index", "Home", new { Area = "Models"});
                                    //"Home/Index.cshtml";
                                    //RedirectToAction("Index", "Home", new { Area = "Models"});
                    return Redirect(returnUrl);
                }
            }
            return View(details);
        }
        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Models" });
        }
    }

}