using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShelf.Models
{
    public class Estante
    {
        public long EstanteID { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public Livro[] livros { get; set; }

    }
}