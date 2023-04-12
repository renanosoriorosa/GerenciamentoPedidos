using GP.Models.Enums;
using GP.Models.Models;

namespace GP.API.Tests.ProdutoTests
{
    [CollectionDefinition(nameof(ProdutoCollection))]
    public class ProdutoCollection : ICollectionFixture<ProdutoTestsFixture>
    {}

    public class ProdutoTestsFixture : IDisposable
    {
        public Produto GerarProdutoValido()
        {
            var Produto = new Produto(
                "666",
                "Produto 666",
                "texto descrição",
                TipoProdutoEnum.ProdutoFinal);

            return Produto;
        }

        public Produto GerarProdutoInValido()
        {
            var Produto = new Produto(
                "",
                "",
                "2",
                TipoProdutoEnum.ProdutoIntermediario);

            return Produto;
        }

        public Produto GerarProdutoInValidoComCamposMaximosUltrapassados()
        {
            var Produto = new Produto(
                "99999999999",
                "9999999999999999999999999999999",
                "",
                TipoProdutoEnum.ProdutoIntermediario);

            return Produto;
        }

        public void Dispose()
        {
        }
    }
}