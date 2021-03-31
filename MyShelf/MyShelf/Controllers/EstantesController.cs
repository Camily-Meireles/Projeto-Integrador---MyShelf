using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MyShelf.Models;
using MyShelf.Context;
using System.Net;

namespace MyShelf.Controllers
{
    public class EstantesController : Controller
    {
        private EFContext context = new EFContext();

        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria() {CategoriaID = 1, Nome = "HQ's"},
            new Categoria() {CategoriaID = 2, Nome = "Ficção"},
            new Categoria() {CategoriaID = 3, Nome = "Romance"},
            new Categoria() {CategoriaID = 4, Nome = "Terror"},
            new Categoria() {CategoriaID = 5, Nome = "Suspense"},
             new Categoria() {CategoriaID = 6, Nome = "Outro"}
        };

        // GET: Estantes
        public ActionResult Index()
        {
            return View(context.Estantes.OrderBy(c => c.Nome));
        }

        // GET: Create 
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(categorias, "CategoriaID", "Nome");
            return View();
        }
        // POST: Estantes/Create
        [HttpPost]
        public ActionResult Create(Estante estante)
        {
            try
            {
                // TODO: Add insert logic here
                context.Estantes.Add(estante);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.CategoriaID = new SelectList(categorias, "CategoriaID", "Nome");
                return View(estante);
            }
        }

        // GET: Fabricantes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estante estante = context.Estantes.Find(id);
            if (estante == null)
            {
                return HttpNotFound();
            }
            return View(estante);
        }

        // POST: Fabricantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Estante estante)
        {
            if (ModelState.IsValid)
            {
                context.Entry(estante).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estante);
        }

        // GET: Fabricantes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return View();
            }
            Estante estante = context.Estantes.Find(id);
            if (estante == null)
            {
                return HttpNotFound();
            }
            return View(estante);
        }

        // GET: Fabricantes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estante estante = context.Estantes.Find(id);
            if (estante == null)
            {
                return HttpNotFound();
            }
            return View(estante);
        }

        // POST: Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Estante estante = context.Estantes.Find(id);
            context.Estantes.Remove(estante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}