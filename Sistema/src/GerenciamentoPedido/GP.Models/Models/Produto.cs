using GP.Models.Enums;
using GP.Models.Models.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GP.Models.Models
{
    public class Produto : Entity
    {
        [Required]
        public string Codigo { get; private set; }

        [Required]
        public string Nome { get; private set; }
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
