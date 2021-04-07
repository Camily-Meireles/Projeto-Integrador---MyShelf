using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Models;
using Persistencia.Contexts;

namespace Persistencia.DAL.Models
{
    public class EstanteDAL
    {
        private EFContext context = new EFContext();
        
        public IQueryable<Estante> ObterEstantesPorUsuario(string userName)
        {
            return context.Estantes.Where(p => p.UsuarioID == userName);
        }
        public IQueryable<Estante> ObterEstantesClassificadasPorNome()
        {
            return context.Estantes.OrderBy(b => b.Nome);
        }
        public IQueryable<Estante> ObterEstantesPorCategoria(long id)
        {
            return context.Estantes.Where(p => p.CategoriaID == id);
        }
        public Estante ObterEstantePorId(long? id)
        {
            return context.Estantes.Where(p => p.EstanteID == id).First();
        }
        public void GravarEstante(Estante estante)
        {
            if (estante.EstanteID == null)
            {
                context.Estantes.Add(estante);
            }
            else
            {
                context.Entry(estante).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Estante EliminarEstantePorId(long id)
        {
            Estante estante = ObterEstantePorId(id);
            context.Estantes.Remove(estante);
            context.SaveChanges();
            return estante;
        }
    }
}