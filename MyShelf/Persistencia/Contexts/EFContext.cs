using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Modelo.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using Persistencia.Migrations;

namespace Persistencia.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("DB_MyShelf")
        {
            Database.SetInitializer<EFContext>(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
        }
        public DbSet<Estante> Estantes { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}