using GP.Models.Models;
using Xunit;

namespace GP.API.Tests.EstoqueTests
{
    [Collection(nameof(EstoqueCollection))]
    public class EstoqueTests
    {
        private readonly EstoqueTestsFixture _EstoqueTestsFixture;

        public EstoqueTests(EstoqueTestsFixture EstoqueTestsFixture)
        {
            _EstoqueTestsFixture = EstoqueTestsFixture;
        }

        [Fact(DisplayName = "Novo Estoque Válido")]
        [Trait("Categoria", "Estoque Testes")]
        public void Estoque_NovoEstoque_DeveEstarValido()
        {
            // Arrange
            var Estoque = _EstoqueTestsFixture.GerarEstoqueValido();

            // Act
            var result = Estoque.EhValido();

            // Assert 
            Assert.True(result);
            Assert.True(Estoque.Ativo);
            Assert.Empty(Estoque.ValidationResult.Errors);
        }

        [Fact(DisplayName = "Novo Estoque Invalido")]
        [Trait("Categoria", "Estoque Testes")]
        public void Estoque_NovoEstoque_DeveEstarInvalido()
        {
            // Arrange
            var Estoque = _EstoqueTestsFixture.GerarEstoqueInValido();

            // Act
            var result = Estoque.EhValido();

            // Assert 
            Assert.False(result);
            Assert.Equal(3,Estoque.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "Novo Estoque Invalido Limite Dos Campos")]
        [Trait("Categoria", "Estoque Testes")]
        public void Estoque_NovoEstoque_DeveEstarInvalidoLimiteCampos()
        {
            // Arrange
            var Estoque = _EstoqueTestsFixture.GerarEstoqueInValidoComCamposMaximosUltrapassados();

            // Act
            var result = Estoque.EhValido();

            // Assert 
            Assert.False(result);
            Assert.Equal(2, Estoque.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "Inativar Estoque")]
        [Trait("Categoria", "Estoque Testes")]
        public void Estoque_InativarEstoque_DeveInativarEstoque()
        {
            // Arrange
            var estoque = _EstoqueTestsFixture.GerarEstoqueValido();

            // Act
            estoque.Inativar();

            // Assert 
            Assert.False(estoque.Ativo);
        }

        [Fact(DisplayName = "Ativar Estoque")]
        [Trait("Categoria", "Estoque Testes")]
        public void Estoque_AtivarEstoque_DeveAtivarEstoque()
        {
            // Arrange
            var estoque = _EstoqueTestsFixture.GerarEstoqueValido();

            // Act
            estoque.Ativar();

            // Assert 
            Assert.True(estoque.Ativo);
        }
    }
}
