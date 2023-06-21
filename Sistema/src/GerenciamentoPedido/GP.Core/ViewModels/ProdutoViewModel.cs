using GP.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Core.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "O campo precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [StringLength(30, ErrorMessage = "O campo precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [StringLength(200, ErrorMessage = "O campo precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Descricao { get; set; }

        public int TipoProduto { get; set; }
    }
}
