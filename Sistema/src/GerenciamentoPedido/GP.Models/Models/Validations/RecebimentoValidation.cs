using FluentValidation;

namespace GP.Models.Models.Validations
{
    public class RecebimentoValidation : AbstractValidator<Recebimento>
    {
        public RecebimentoValidation()
        {
            RuleFor(c => c.Codigo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 10).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            
            RuleFor(c => c.NF)
                .Length(3, 30)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}