using GP.Models.Enums;
using GP.Models.Models.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GP.Models.Models
{
    public class Produto : Entity
    {
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string Codigo { get; private set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Nome { get; private set; }


        [StringLength(200, MinimumLength = 3)]
        public string Descricao { get; private set; }

        public TipoProdutoEnum TipoProduto { get; private set; }

        public ICollection<CodigoBarrasVolume> Volumes { get; }

        public Produto()
        {
        }

        public Produto(string codigo, string nome, string descricao, TipoProdutoEnum tipoProduto)
        {
            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            TipoProduto = tipoProduto;
        }

        public override bool EhValido()
        {
            ValidationResult = new ProdutoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
