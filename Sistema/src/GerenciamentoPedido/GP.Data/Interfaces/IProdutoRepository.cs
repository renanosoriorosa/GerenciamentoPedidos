using GP.Models.Enums;
using GP.Models.Models;

namespace GP.Data.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorTipo(TipoProdutoEnum tipo);
        Task<IEnumerable<Produto>> ObterProdutosPorTipoAsNotracking(TipoProdutoEnum tipo);
    }
}