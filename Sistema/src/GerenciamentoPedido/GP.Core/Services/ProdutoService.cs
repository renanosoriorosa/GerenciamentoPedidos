using GP.Core.Interfaces;
using GP.Core.ViewModels;
using GP.Data.Interfaces;
using GP.Models.Models;
using GP.Models.Models.Validations;
using AutoMapper;
namespace GP.Core.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository,
                              IMapper mapper,
                              INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _produtoRepository.Atualizar(produto);
        }

        public async Task Remover(int id)
        {
            await _produtoRepository.Remover(id);
        }

        public async Task<ProdutoViewModel> ObterPorId(int id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));
        }

        public async Task<ProdutoViewModel> ObterPorIdAsNoTracking(int id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorIdAsNoTracking(id));
        }

        public async Task<List<ProdutoViewModel>> ObterTodos()
        {
            return _mapper.Map<List<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}