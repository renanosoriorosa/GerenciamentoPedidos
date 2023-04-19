using FluentValidation;

namespace GP.Models.Models.Validations
{
    public class CodigoBarrasVolumeValidation : AbstractValidator<CodigoBarrasVolume>
    {
        public CodigoBarrasVolumeValidation()
        {
            RuleFor(c => c.CodigoBarras)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(12).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            
            RuleFor(c => c.PrecoUnitario)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.QuantidadeEntrada)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}