using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Modelo.Models
{
    public class Livro
    {
        public long? LivroID { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Informe o nome do Livro")]
        public string Nome { get; set; }

        [DisplayName("Autor(a)")]
        [Required(ErrorMessage = "Informe o nome do autor")]
        public string Autor { get; set; }

        [DisplayName("Ano de Lançamento")]
        public string AnoLancamento { get; set; }

        [DisplayName("Sinopse")]
        [Required(ErrorMessage = "Informe a descrição do livro (Não precisa ser a sinopse original)")]
        public string Descricao { get; set; }

        [DisplayName("Estante")]
        public long EstanteID { get; set; }
        public string UsuarioID { get; set; }
        public Estante estante { get; set; }
    }
}