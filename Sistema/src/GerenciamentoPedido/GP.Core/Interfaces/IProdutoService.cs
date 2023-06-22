using GP.Core.ViewModels;
using GP.Models.Models;

namespace GP.Core.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(int id);
        Task<ProdutoViewModel> ObterPorId(int id);
        Task<List<ProdutoViewModel>> ObterTodos();
        Task<ProdutoViewModel> ObterPorIdAsNoTracking(int id);
    }
}