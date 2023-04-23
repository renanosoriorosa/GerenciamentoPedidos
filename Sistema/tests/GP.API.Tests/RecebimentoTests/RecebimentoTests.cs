using Xunit;

namespace GP.API.Tests.RecebimentoTests
{
    [Collection(nameof(RecebimentoCollection))]
    public class RecebimentoTests
    {
        private readonly RecebimentoTestsFixture _RecebimentoTestsFixture;

        public RecebimentoTests(RecebimentoTestsFixture RecebimentoTestsFixture)
        {
            _RecebimentoTestsFixture = RecebimentoTestsFixture;
        }

        [Fact(DisplayName = "Novo Recebimento Válido")]
        [Trait("Categoria", "Recebimento Testes")]
        public void Recebimento_NovoRecebimento_DeveEstarValido()
        {
            // Arrange
            var Recebimento = _RecebimentoTestsFixture.GerarRecebimentoValidoComVolumes();

            // Act
            var result = Recebimento.EhValido();

            // Assert 
            Assert.True(result);
            Assert.Empty(Recebimento.ValidationResult.Errors);
        }

        [Fact(DisplayName = "Finalizar Recebimento Válido")]
        [Trait("Categoria", "Recebimento Testes")]
        public void Recebimento_FinalizarRecebimento_DeveEstarValido()
        {
            // Arrange
            var Recebimento = _RecebimentoTestsFixture.GerarRecebimentoValidoComVolumes();
            Recebimento.Finalizar();
            // Act
            var result = Recebimento.EhValido();

            // Assert 
            Assert.True(result);
            Assert.True(Recebimento.isFinalizado());
            Assert.Empty(Recebimento.ValidationResult.Errors);
        }

        [Fact(DisplayName = "Finalizar Recebimento Invalido")]
        [Trait("Categoria", "Recebimento Testes")]
        public void Recebimento_FinalizarRecebimento_DeveEstarInvalido()
        {
            // Arrange
            var Recebimento = _RecebimentoTestsFixture.GerarRecebimentoValidoSemVolumes();
            Recebimento.Finalizar();
            // Act
            var result = Recebimento.EhValido();

            // Assert 
            Assert.True(result);
            Assert.False(Recebimento.isFinalizado());
        }

        [Fact(DisplayName = "Cancelar Recebimento Valido")]
        [Trait("Categoria", "Recebimento Testes")]
        public void Recebimento_CancelarRecebimento_DeveEstarValido()
        {
            // Arrange
            var Recebimento = _RecebimentoTestsFixture.GerarRecebimentoValidoComVolumes();
            Recebimento.Cancelar();

            // Act
            var result = Recebimento.EhValido();

            // Assert 
            Assert.True(result);
            Assert.True(Recebimento.isCancelado());
        }

        [Fact(DisplayName = "Cancelar Recebimento Invalido")]
        [Trait("Categoria", "Recebimento Testes")]
        public void Recebimento_CancelarRecebimento_DeveEstarInvalido()
        {
            // Arrange
            var Recebimento = _RecebimentoTestsFixture.GerarRecebimentoValidoComVolumes();

            //consome um volume
            var volume = Recebimento.Volumes.FirstOrDefault();
            volume.Consumir(1);

            Recebimento.Cancelar();

            // Act
            var result = Recebimento.EhValido();

            // Assert 
            Assert.True(result);
            Assert.False(Recebimento.isCancelado());
        }
    }
}
