using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShelf.Models
{
    public class Livro
    {
        public long? LivroID { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string AnoLancamento { get; set; }
        public string Descricao { get; set; }
        public long EstanteID { get; set; }
        public Estante estante { get; set; }
    }
}