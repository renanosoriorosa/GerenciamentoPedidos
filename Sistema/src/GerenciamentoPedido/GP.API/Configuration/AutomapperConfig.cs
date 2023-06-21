using AutoMapper;
using GP.Core.ViewModels;
using GP.Models.Models;

namespace GP.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
