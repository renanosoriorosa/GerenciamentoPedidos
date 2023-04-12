using GP.Models.Enums;
using GP.Models.Models.Validations;

namespace GP.Models.Models
{
    public class Produto : Entity
    {
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public TipoProdutoEnum TipoProduto { get; private set; }

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
