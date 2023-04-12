using GP.Data.Context;
using GP.Data.Interfaces;
using GP.Models.Enums;
using GP.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace GP.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(GPContext context) : base(context) { }

        public async Task<IEnumerable<Produto>> ObterProdutosPorTipo(TipoProdutoEnum tipo)
        {
            return await _context.Produto
                .Where(obj => obj.TipoProduto == tipo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorTipoAsNotracking(TipoProdutoEnum tipo)
        {
            return await _context.Produto
                .Where(obj => obj.TipoProduto == tipo)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}