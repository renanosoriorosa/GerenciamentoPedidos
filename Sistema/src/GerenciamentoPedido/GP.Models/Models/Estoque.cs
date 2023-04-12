using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Models.Models
{
    public class Estoque : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(10)]
        public string Nome { get; private set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Informe entre {1} a {0} caracteres.")]
        public string Descricao { get; private set; }

    }
}
