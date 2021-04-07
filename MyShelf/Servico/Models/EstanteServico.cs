using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Models;
using Persistencia.DAL.Models;

namespace Servico.Models
{
    public class EstanteServico
    {
        private EstanteDAL estanteDAL = new EstanteDAL();
        public IQueryable<Estante> ObterEstantesClassificadasPorNome()
        {
            return estanteDAL.ObterEstantesClassificadasPorNome();
        }
        public Estante ObterEstantePorId(long id)
        {
            return estanteDAL.ObterEstantePorId(id);
        }
        public void GravarEstante(Estante estante)
        {
            estanteDAL.GravarEstante(estante);
        }
        public Estante EliminarEstantePorId(long id)
        {
            return estanteDAL.EliminarEstantePorId(id);
        }
        public IQueryable<Estante> ObterEstantesPorCategoria(long id)
        {
            return estanteDAL.ObterEstantesPorCategoria(id);
        }
        public IQueryable<Estante> ObterEstantesPorUsuario(string userName)
        {
            return estanteDAL.ObterEstantesPorUsuario(userName);
        }
    }
}
