using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShelf.Models
{
    public class Usuario
    {
        public long UsuarioID { get; set; }
        public string User { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime Date_Nasc { get; set; }

        ///public virtual ICollection<Estante> Estantes {get; set;}
    }
}