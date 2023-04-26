using GP.API.Interfaces;
using GP.API.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GP.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;
        private readonly IUser AppUser;

        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        protected MainController(INotificador notificador, IUser appUser)
        {
            _notificador = notificador;
            AppUser = appUser;

            if (AppUser.IsAuthenticated())
            {
                UsuarioId = AppUser.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    message = result
                });
            }

            return BadRequest(new
            {
                success = false,
                message = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);

            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values
                .SelectMany(obj => obj.Errors);

            foreach (var erro in erros)
            {
                var errorMessage = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;

                NotificarErro(errorMessage);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
