using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using MyShelf.Models;
using MyShelf.Context;

namespace MyShelf.Controllers
{
    public class LivrosController : Controller
    {

        private EFContext context = new EFContext();
        // GET: Livros
        public ActionResult Index()
        {
            return View(context.Livros.OrderBy(c => c.Nome));
        }

        // GET: Create 
        public ActionResult Create()
        {
            ViewBag.EstanteID = new SelectList(context.Estantes.OrderBy(b => b.Nome), "EstanteID", "Nome");
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Livro livro)
        {
            try
            {
                context.Livros.Add(livro);
                context.SaveChanges();
                return RedirectToAction("Details", "Estantes", new { id = livro.EstanteID});
            }
            catch
            {
                //ViewBag.EstanteID = new SelectList(context.Estantes.OrderBy(b => b.Nome), "CategoriaID", "Nome");
                return View(livro);
            }
        }

        // GET: Livros/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = context.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstanteID = new SelectList(context.Estantes.OrderBy(b => b.Nome), "EstanteID","Nome", livro.EstanteID);
            return View(livro);
        }

        // POST: Livros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Livro livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(livro).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Details", "Estantes", new { id = livro.EstanteID});
                }
                return View(livro);
            }
            catch
            {
                return View(livro);
            }
        }

        // GET: Livros/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = context.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }
        // GET: Fabricantes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = context.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        // POST: Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Livro livro = context.Livros.Find(id);
            long x = livro.EstanteID;
            context.Livros.Remove(livro);
            context.SaveChanges();
            return RedirectToAction("Details", "Estantes", new { id = x });
        }
    }
}