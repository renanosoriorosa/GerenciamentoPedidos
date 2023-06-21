using GP.Models.Models.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GP.Models.Models
{
    public class Estoque : Entity
    {
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string Nome { get; private set; }

        [StringLength(200, MinimumLength = 2)]
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }

        public ICollection<CodigoBarrasVolume> Volumes { get; }

        public Estoque()
        {
        }

        public Estoque(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = true;
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public override bool EhValido()
        {
            ValidationResult = new EstoqueValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}
