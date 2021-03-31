using MyShelf.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShelf.Models;
using System.Data.Entity;
using System.Net;

namespace MyShelf.Controllers
{
    public class UsuarioController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Usuario
        public ActionResult Index()
        {
            return View(context.Usuario.OrderBy(c => c.Nome));
        }

        //GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                context.Usuario.Add(usuario);
                context.SaveChanges();
                return RedirectToAction(actionName:"Index", controllerName: "Home");
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = context.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            //ViewBag.EstanteID = new SelectList(context.Estantes.OrderBy(b => b.Nome), "EstanteID", "Nome", livro.estante.EstanteID);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(usuario).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                return View(usuario);
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: Usuario/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = context.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        // GET: Usuario/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = context.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Usuario usuario = context.Usuario.Find(id);
            context.Usuario.Remove(usuario);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        //GET : Usuario/Login
        public ActionResult Login()
        {
            return View();
        }
        //POST : Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string user, string senha)
        {
            //context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            var usuario = (from a in context.Usuario where a.User == user
                           && a.Senha == senha select a).FirstOrDefault<Usuario>();
            if (usuario == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}