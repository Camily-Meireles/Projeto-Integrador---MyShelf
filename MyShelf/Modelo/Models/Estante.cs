using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Modelo.Models
{
    public class Estante
    {
        [DisplayName("id")]
        public long? EstanteID { get; set; }
        [DisplayName("Usuario")]
        public string UsuarioID { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Informe o nome da estante")]
        public string Nome { get; set; }
        [DisplayName("Categoria")]
        public long? CategoriaID { get; set; }

        public Categoria Categoria { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }

    }
}