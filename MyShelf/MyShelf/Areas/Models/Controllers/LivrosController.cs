using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Servico.Models;
using Modelo.Models;

namespace MyShelf.Areas.Models.Controllers
{
    public class LivrosController : Controller
    {
        private EstanteServico estanteServico = new EstanteServico();
        private LivroServico livroServico = new LivroServico();
        private ActionResult ObterVisaoLivroPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = livroServico.ObterLivroPorId((long)id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }
        // Metodo Privado 
        private ActionResult GravarLivro(Livro livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    livroServico.GravarLivro(livro);
                    return RedirectToAction("Details", "Estantes", new { id = livro.EstanteID});
                }
                //PopularViewBag(livro);
                return View(livro);
            }
            catch
            {
                return View(livro);
            }
        }
        // Metodo Privado
        private void PopularViewBag(Estante estante = null)
        {
            if (estante == null)
            {
                ViewBag.EstanteID = new SelectList(estanteServico.ObterEstantesClassificadasPorNome(), "EstanteID", "Nome");
            }
            else
            {
                ViewBag.EstanteID = new SelectList(estanteServico.ObterEstantesClassificadasPorNome(), "EstanteID", "Nome", estante.EstanteID);
            }
        }

        // GET: Livros
        [Authorize(Roles = "Moderador")]
        public ActionResult Index()
        {
            return View(livroServico.ObterLivrosClassificadosPorNome());
        }

        // GET: Produtos/Create
        [Authorize]
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }
        // POST: Estantes/Create
        [HttpPost]
        public ActionResult Create(Livro livro, string userName)
        {
            livro.UsuarioID = userName;
            return GravarLivro(livro);
        }
        //GET : Edit
        [Authorize]
        public ActionResult Edit(long? id, long? id2)
        {

            PopularViewBag(estanteServico.ObterEstantePorId((long) id2));
            return ObterVisaoLivroPorId(id);
        }

        // POST: Livros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Livro livro)
        {
            return GravarLivro(livro);
        }

        // GET: Livros/Details/5
        public ActionResult Details(long? id)
        {
            return ObterVisaoLivroPorId(id);
        }
        // GET: Fabricantes/Delete/5
        [Authorize]
        public ActionResult Delete(long? id)
        {
            return ObterVisaoLivroPorId(id);
        }

        // POST: Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Livro livro = livroServico.EliminarLivroPorId(id);
                TempData["Message"] = "Livro " + livro.Nome.ToUpper() + " foi excluído";
                return RedirectToAction("Index", "Estantes", new { id = livro.EstanteID});
            }
            catch
            {
                return View();
            }
        }
    }
}