using GP.Models.Enums;
using GP.Models.Models.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GP.Models.Models
{
    public class Recebimento : Entity
    {
        [Required]
        public string Codigo { get; private set; }

        [Required]
        public string NF { get; private set; }

        public DateTime DataHora { get; private set; }

        public RecebimentoStatusEnum Status { get; private set; }

        public ICollection<CodigoBarrasVolume> Volumes { get; }

        public Recebimento()
        {
        }
        

        public override bool EhValido()
        {
            ValidationResult = new RecebimentoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
