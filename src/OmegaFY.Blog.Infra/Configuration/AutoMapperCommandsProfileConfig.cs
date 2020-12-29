using AutoMapper;
using OmegaFY.Blog.Application.Commands.Postagens.EditarDadosPostagem;
using OmegaFY.Blog.Application.Commands.Postagens.PublicarPostagem;
using OmegaFY.Blog.Domain.Entities.Postagens;
using OmegaFY.Blog.WebAPI.Models.CommandsViewModels;

namespace OmegaFY.Blog.Infra.Configuration
{

    public class AutoMapperCommandsProfileConfig : Profile
    {

        public AutoMapperCommandsProfileConfig()
        {

            CreateMap<PublicarPostagemViewModel, PublicarPostagemCommand>(); //.ReverseMap();
            CreateMap<EditarDadosPostagemViewModel, EditarDadosPostagemCommand>();

            CreateMap<Postagem, PublicarPostagemCommandResult>()
                .ConvertUsing(postagem => new PublicarPostagemCommandResult()
                {
                    Id = postagem.Id,
                    UsuarioId = postagem.UsuarioId,
                    Titulo = postagem.Cabecalho.Titulo,
                    SubTitulo = postagem.Cabecalho.SubTitulo,
                    Corpo = postagem.Corpo,
                    DataCriacao = postagem.DetalhesModificacao.DataCriacao
                });
        }

    }

}
