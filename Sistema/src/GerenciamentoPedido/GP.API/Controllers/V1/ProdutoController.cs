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
    //[Authorize]
    [Route("v{version:apiVersion}/[controller]/[action]")]
    public class ProdutoController : MainController
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService,
            IMapper mapper,
            INotificador notificador, IUser user) : base(notificador, user)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
        {
            //if obsoleto
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse(produtoViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProdutoViewModel>> Atualizar(int id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return SendBadRequest("Id mismatch");

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse(produtoViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(int id)
        {
            var produtoViewModel = await _produtoService.ObterPorIdAsNoTracking(id);

            if (produtoViewModel == null) return SendBadRequest($"Produto com id {id} não encontrado");

            await _produtoService.Remover(id);

            return CustomResponse(produtoViewModel);
        }

        [HttpGet]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(int id)
        {
            var produtoViewModel = await _produtoService.ObterPorId(id);

            if (produtoViewModel == null) return SendBadRequest($"Produto com id {id} não encontrado");

            return CustomResponse(produtoViewModel);
        }


        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            var produtos = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoService.ObterTodos());

            return CustomResponse(produtos);
        }
    }
}
