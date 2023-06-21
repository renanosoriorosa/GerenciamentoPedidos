using GP.API.Interfaces;
using GP.Core.Interfaces;
using GP.Data.Interfaces;
using GP.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GP.Core.ViewModels;

namespace GP.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("v{version:apiVersion}/[controller]/[action]")]
    public class ProdutoController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepository produtoRepository,
            IProdutoService produtoService,
            IMapper mapper,
            INotificador notificador, IUser user) : base(notificador, user)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var produto = _mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);

            await _produtoService.Adicionar(produto);

            return CustomResponse(produtoViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            var produtos = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos());

            return CustomResponse(produtos);
        }
    }
}
