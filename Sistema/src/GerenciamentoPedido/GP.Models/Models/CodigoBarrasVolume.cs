using GP.Models.Enums;
using GP.Models.Models.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GP.Models.Models
{
    public class CodigoBarrasVolume : Entity
    {
        [Required]
        public string CodigoBarras { get; private set; }

        [Required]
        public Double PrecoUnitario { get; private set; }

        public int QuantidadeEntrada { get; private set; }
        public int QuantidadeReservada { get; private set; }
        public int QuantidadeSaida { get; private set; }

        public int RecebimentoId { get; private set; }
        public virtual Recebimento Recebimento { get; private set; }

        public int ProdutoId { get; private set; }
        public virtual Produto Produto { get; private set; }

        public int EstoqueId { get; private set; }
        public virtual Estoque Estoque { get; private set; }

        public CodigoBarrasStatusEnum Status { get; private set; }

        public CodigoBarrasVolume()
        {
        }
        

        public override bool EhValido()
        {
            ValidationResult = new CodigoBarrasVolumeValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
