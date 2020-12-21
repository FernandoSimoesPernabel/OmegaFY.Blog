using AutoMapper;
using OmegaFY.Blog.Application.Commands.Postagens.EditarDadosPostagem;
using OmegaFY.Blog.Application.Commands.Postagens.PublicarPostagem;
using OmegaFY.Blog.WebAPI.Models.CommandsViewModels;

namespace OmegaFY.Blog.Infra.Configuration
{

    public class AutoMapperCommandsProfileConfig : Profile
    {

        public AutoMapperCommandsProfileConfig()
        {
            //CreateMap<PublicarPostagemViewModel, PublicarPostagemCommand>()
            //    .ConstructUsing(vm => new PublicarPostagemCommand(vm.Titulo, vm.SubTitulo, vm.ConteudoPostagem));

            CreateMap<PublicarPostagemViewModel, PublicarPostagemCommand>(); //.ReverseMap();
            CreateMap<EditarDadosPostagemViewModel, EditarDadosPostagemCommand>();
        }

    }

}
