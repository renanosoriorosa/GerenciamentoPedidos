using GP.Models.Enums;
using GP.Models.Models.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GP.Models.Models
{
    public class Recebimento : Entity
    {
        [Required]
        [StringLength(12)]
        public string Codigo { get; private set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string NF { get; private set; }

        public DateTime DataHora { get; private set; }

        public RecebimentoStatusEnum Status { get; private set; }

        public ICollection<CodigoBarrasVolume> Volumes { get; }

        public Recebimento()
        {
        }

        public Recebimento(string nF)
        {
            GerarCodigo();
            NF = nF;
            DataHora = DateTime.Now;
            Status = RecebimentoStatusEnum.Iniciado;
        }

        public void GerarCodigo()
        {
            Random numAleatorio = new Random();
            Codigo = "RB" + numAleatorio.Next(1, 999999999).ToString().PadLeft(10, '0');
        }

        public void Cancelar()
        {
            if (Volumes != null && Volumes.Count > 0)
            {
                if (PodeCancelar())
                {
                    foreach (var volume in Volumes)
                        volume.Cancelar();

                    Status = RecebimentoStatusEnum.Cancelado;
                }
            }
        }

        public bool PodeCancelar()
        {
            if (Volumes != null && Volumes.Count > 0)
            {
                if (Volumes.Any(volume => volume.PodeCancelar() == false))
                    return false;
                else
                    return true;
            }

            return false;
        }

        public void Finalizar()
        {
            Status = RecebimentoStatusEnum.Finalizado;
        }

        public override bool EhValido()
        {
            ValidationResult = new RecebimentoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
