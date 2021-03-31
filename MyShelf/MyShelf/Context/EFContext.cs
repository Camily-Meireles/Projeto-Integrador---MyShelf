using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MyShelf.Models;

namespace MyShelf.Context
{
    public class EFContext : System.Data.Entity.DbContext
    {
        public EFContext() : base("DB_MyShelf")
        {
            Database.SetInitializer<EFContext>(
            new DropCreateDatabaseIfModelChanges<EFContext>());
        }
        public DbSet<Estante> Estantes { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}