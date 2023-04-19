using GP.Models.Enums;
using GP.Models.Models.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GP.Models.Models
{
    public class CodigoBarrasVolume : Entity
    {
        [Required]
        [StringLength(12)]
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

        public CodigoBarrasVolume(
            double precoUnitario, 
            int quantidadeEntrada, 
            int recebimentoId, 
            int produtoId, 
            int estoqueId)
        {
            GerarCodigo();
            PrecoUnitario = precoUnitario;
            QuantidadeEntrada = quantidadeEntrada;
            RecebimentoId = recebimentoId;
            ProdutoId = produtoId;
            EstoqueId = estoqueId;
            Status = CodigoBarrasStatusEnum.Recebendo;
        }

        public void GerarCodigo()
        {
            Random numAleatorio = new Random();
            CodigoBarras = "CB" + numAleatorio.Next(1, 999999999).ToString().PadLeft(10, '0');
        }

        public int ObterQuantidadeDisponivel()
        {
            return QuantidadeEntrada - QuantidadeReservada - QuantidadeSaida;
        }

        private void TornarDisponivel()
        {
            Status = CodigoBarrasStatusEnum.Disponivel;
        }

        private void TornarReservado()
        {
            Status = CodigoBarrasStatusEnum.Reservado;
        }

        private void TornarConsumido()
        {
            Status = CodigoBarrasStatusEnum.Consumido;
        }

        public void Cancelar()
        {
            if(PodeCancelar())
                Status = CodigoBarrasStatusEnum.Cancelado;
        }

        public void Expedir()
        {
            Status = CodigoBarrasStatusEnum.Expedido;
        }

        public void Consumir(int quantidade)
        {
            QuantidadeSaida += quantidade;

            if (ObterQuantidadeDisponivel() <= 0 && QuantidadeReservada == 0)
                TornarConsumido();
        }

        public void ReservarQuantidade(int quantidade)
        {
            QuantidadeReservada += quantidade;

            if (ObterQuantidadeDisponivel() <= 0)
                TornarReservado();
        }

        public void RemoverReserva(int quantidade)
        {
            QuantidadeReservada -= quantidade;

            if (ObterQuantidadeDisponivel() <= 0)
                TornarReservado();
        }

        public void AdicionarEntrada(int quantidade)
        {
            QuantidadeEntrada += quantidade;

            if (ObterQuantidadeDisponivel() > 0)
                TornarDisponivel();
        }

        public override bool EhValido()
        {
            ValidationResult = new CodigoBarrasVolumeValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool PodeCancelar()
        {
            if(QuantidadeReservada > 0 || QuantidadeSaida > 0)
                return false;

            return true;    
        }
    }
}
