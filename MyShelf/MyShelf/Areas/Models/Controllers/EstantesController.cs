using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Modelo.Models;
using System.Net;
using Servico.Models;
using MyShelf.Infraestrutura;

namespace MyShelf.Areas.Models.Controllers
{
    public class EstantesController : Controller
    {
        private EstanteServico estanteServico = new EstanteServico();
        private LivroServico livroServico = new LivroServico();

        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria() {CategoriaID = 1, Nome = "HQ's"},
            new Categoria() {CategoriaID = 2, Nome = "Ficção"},
            new Categoria() {CategoriaID = 3, Nome = "Romance"},
            new Categoria() {CategoriaID = 4, Nome = "Terror"},
            new Categoria() {CategoriaID = 5, Nome = "Suspense"},
            new Categoria() {CategoriaID = 6, Nome = "Outro"}
        };
 
        private ActionResult ObterVisaoEstantePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estante estante = estanteServico.ObterEstantePorId((long)id);
            if (estante == null)
            {
                return HttpNotFound();
            }
            return View(estante);
        }
        // Metodo Privado 
        private ActionResult GravarEstante(Estante estante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    estanteServico.GravarEstante(estante);
                    return RedirectToAction("Index", "Estantes", new { id = estante.CategoriaID});
                }
                return View(estante);
            }
            catch
            {
                return View(estante);
            }
        }

        public ActionResult EstantesPorUsuario(string userName)
        {
            return View(estanteServico.ObterEstantesPorUsuario(userName));
        }
        // GET: Estantes
        public ActionResult Index(long id)
        {
            //return View(estanteServico.ObterEstantesClassificadasPorNome());
            return View(estanteServico.ObterEstantesPorCategoria(id));
        }

        // GET: Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(categorias, "CategoriaID", "Nome");
            return View();
        }
        // POST: Estantes/Create
        [HttpPost]
        public ActionResult Create(Estante estante, string userName)
        {
            estante.UsuarioID = userName;
            return GravarEstante(estante);
        }

        // GET: Estantes/Edit/5
        [Authorize]
        public ActionResult Edit(long? id)
        {
            ViewBag.CategoriaID = new SelectList(categorias, "CategoriaID", "Nome");
            //Estante estante = estanteServico.ObterEstantePorId((long)id);
            //return View(estante);
            return ObterVisaoEstantePorId(id);
        }

        // POST: Estantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Estante estante)
        {
            return GravarEstante(estante);
        }

        // GET: Fabricantes/Details/5
        public ActionResult Details(long? id)
        {
            return ObterVisaoEstantePorId(id);
        }

        // GET: Fabricantes/Delete/5
        [Authorize]
        public ActionResult Delete(long? id)
        {
            return ObterVisaoEstantePorId(id);
        }

        // POST: Estante/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Estante estante = estanteServico.ObterEstantePorId(id);
                long? x = estante.CategoriaID;
                estanteServico.EliminarEstantePorId(id);
                TempData["Message"] = "Estante " + estante.Nome.ToUpper() + " foi excluída";
                return RedirectToAction("Index", "Estantes", new { id = 1 });
            }
            catch
            {
                return View();
            }
        }

    }
}