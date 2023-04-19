using GP.Models.Enums;
using GP.Models.Models;

namespace GP.API.Tests.EstoqueTests
{
    [CollectionDefinition(nameof(EstoqueCollection))]
    public class EstoqueCollection : ICollectionFixture<EstoqueTestsFixture>
    {}

    public class EstoqueTestsFixture : IDisposable
    {
        public Estoque GerarEstoqueValido()
        {
            var Estoque = new Estoque(
                "666",
                "Produto 666");

            return Estoque;
        }

        public Estoque GerarEstoqueInValido()
        {
            var Estoque = new Estoque(
                "",
                "");

            return Estoque;
        }

        public Estoque GerarEstoqueInValidoComCamposMaximosUltrapassados()
        {
            var Estoque = new Estoque(
                "99999999999",
                "22");

            return Estoque;
        }

        public void Dispose()
        {
        }
    }
}