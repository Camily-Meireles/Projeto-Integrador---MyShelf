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
        public EFContext() : base("DB_MyShelf") { }
        public DbSet<Estante> Estantes { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}