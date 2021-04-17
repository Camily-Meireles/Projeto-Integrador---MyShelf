using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Contexts;
using Modelo.Models;
using System.Data.Entity;

namespace Persistencia.DAL.Models
{
    public class LivroDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Livro> ObterLivrosClassificadosPorNome()
        {
            return context.Livros.Include(f => f.estante).OrderBy(n => n.Nome);
        }
        public Livro ObterLivroPorId(long? id)
        {
            return context.Livros.Where(p => p.LivroID == id).Include(e => e.estante).First();
        }
        public void GravarLivro(Livro livro)
        {
            if (livro.LivroID == null)
            {
                context.Livros.Add(livro);
            }
            else
            {
                context.Entry(livro).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Livro EliminarLivroPorId(long id)
        {
            Livro livro = ObterLivroPorId(id);
            context.Livros.Remove(livro);
            context.SaveChanges();
            return livro;
        }
    }
}
