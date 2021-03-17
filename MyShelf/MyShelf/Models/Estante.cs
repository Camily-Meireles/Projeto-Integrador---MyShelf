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
        public long? CategoriaID { get; set; }
        public Categoria Categoria { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }

    }
}