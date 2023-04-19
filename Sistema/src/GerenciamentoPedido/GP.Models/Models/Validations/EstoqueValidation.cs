using FluentValidation;

namespace GP.Models.Models.Validations
{
    public class EstoqueValidation : AbstractValidator<Estoque>
    {
        public EstoqueValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 10).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            
            RuleFor(c => c.Descricao)
                .Length(3, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}