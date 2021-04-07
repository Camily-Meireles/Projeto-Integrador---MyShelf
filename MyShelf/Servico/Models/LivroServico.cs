using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Models;
using Persistencia.DAL.Models;

namespace Servico.Models
{
    public class LivroServico
    {
        private LivroDAL livroDAL = new LivroDAL();
        public IQueryable<Livro> ObterLivrosClassificadosPorNome()
        {
            return livroDAL.ObterLivrosClassificadosPorNome();
        }
        public Livro ObterLivroPorId(long id)
        {
            return livroDAL.ObterLivroPorId(id);
        }
        public void GravarLivro(Livro livro)
        {
            livroDAL.GravarLivro(livro);
        }
        public Livro EliminarLivroPorId(long id)
        {
            return livroDAL.EliminarLivroPorId(id);
        }
    }
}
