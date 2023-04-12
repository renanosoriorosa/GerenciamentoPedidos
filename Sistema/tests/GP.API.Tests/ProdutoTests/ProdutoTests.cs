using Xunit;

namespace GP.API.Tests.ProdutoTests
{
    [Collection(nameof(ProdutoCollection))]
    public class ProdutoTests
    {
        private readonly ProdutoTestsFixture _produtoTestsFixture;

        public ProdutoTests(ProdutoTestsFixture produtoTestsFixture)
        {
            _produtoTestsFixture = produtoTestsFixture;
        }

        [Fact(DisplayName = "Novo Produto Válido")]
        [Trait("Categoria", "Produto Testes")]
        public void Produto_NovoProduto_DeveEstarValido()
        {
            // Arrange
            var produto = _produtoTestsFixture.GerarProdutoValido();

            // Act
            var result = produto.EhValido();

            // Assert 
            Assert.True(result);
            Assert.Empty(produto.ValidationResult.Errors);
        }

        [Fact(DisplayName = "Novo Produto Invalido")]
        [Trait("Categoria", "Produto Testes")]
        public void Produto_NovoProduto_DeveEstarInvalido()
        {
            // Arrange
            var produto = _produtoTestsFixture.GerarProdutoInValido();

            // Act
            var result = produto.EhValido();

            // Assert 
            Assert.False(result);
            Assert.NotEmpty(produto.ValidationResult.Errors);
        }

        [Fact(DisplayName = "Novo Produto Invalido Limite Dos Campos")]
        [Trait("Categoria", "Produto Testes")]
        public void Produto_NovoProduto_DeveEstarInvalidoLimiteCampos()
        {
            // Arrange
            var produto = _produtoTestsFixture.GerarProdutoInValidoComCamposMaximosUltrapassados();

            // Act
            var result = produto.EhValido();

            // Assert 
            Assert.False(result);
            Assert.NotEmpty(produto.ValidationResult.Errors);
        }
    }
}
