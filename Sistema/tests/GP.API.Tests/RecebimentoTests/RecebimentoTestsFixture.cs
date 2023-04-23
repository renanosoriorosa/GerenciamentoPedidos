using GP.Models.Enums;
using GP.Models.Models;

namespace GP.API.Tests.RecebimentoTests
{
    [CollectionDefinition(nameof(RecebimentoCollection))]
    public class RecebimentoCollection : ICollectionFixture<RecebimentoTestsFixture>
    {}

    public class RecebimentoTestsFixture : IDisposable
    {
        public Recebimento GerarRecebimentoValidoComVolumes()
        {
            var recebimento = new Recebimento("98222");

            recebimento.AdicionarVolume(new CodigoBarrasVolume(10, 10, recebimento.Id, 1, 1));
            recebimento.AdicionarVolume(new CodigoBarrasVolume(8, 20, recebimento.Id, 2, 1));

            return recebimento;
        }

        public Recebimento GerarRecebimentoValidoSemVolumes()
        {
            var recebimento = new Recebimento("98222");

            return recebimento;
        }

        public Recebimento GerarRecebimentoInvalidoComVolumes()
        {
            var recebimento = new Recebimento("");

            recebimento.AdicionarVolume(new CodigoBarrasVolume(10, 10, recebimento.Id, 1, 1));
            recebimento.AdicionarVolume(new CodigoBarrasVolume(8, 20, recebimento.Id, 2, 1));

            return recebimento;
        }

        public Recebimento GerarRecebimentoInvalidoSemVolumes()
        {
            var recebimento = new Recebimento("");

            return recebimento;
        }

        public void Dispose()
        {
        }
    }
}