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

        // GET: Estantes
        public ActionResult Index()
        {
            return View(context.Estantes.OrderBy(c => c.Nome));
        }

        // GET: Create 
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estante estante)
        {
            context.Estantes.Add(estante);
            context.SaveChanges();
            return RedirectToAction("Index");
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
            Estante fabricante = context.Estantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
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