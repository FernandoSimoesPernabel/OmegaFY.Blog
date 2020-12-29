using AutoMapper;
using OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem;
using OmegaFY.Blog.Domain.Entities.Postagens;
using OmegaFY.Blog.WebAPI.Models.QueriesViewModels;

namespace OmegaFY.Blog.Infra.Configuration
{

    public class AutoMapperQueriesProfileConfig : Profile
    {

        public AutoMapperQueriesProfileConfig()
        {

            CreateMap<ObterPostagemViewModel, ObterPostagemQuery>();

            CreateMap<Postagem, ObterPostagemQueryResult>()
                .ConvertUsing(postagem => new ObterPostagemQueryResult()
                {
                    Id = postagem.Id,
                    UsuarioId = postagem.UsuarioId,
                    Titulo = postagem.Cabecalho.Titulo,
                    SubTitulo = postagem.Cabecalho.SubTitulo,
                    Corpo = postagem.Corpo,
                    DataCriacao = postagem.DetalhesModificacao.DataCriacao,
                    DataModificacao = postagem.DetalhesModificacao.DataModificacao,
                    TotalDeAvaliacoes = postagem.TotalDeAvaliacoes(),
                    TotalDeComentarios = postagem.TotalDeComentarios(),
                    TotalDeCompartilhamentos = postagem.TotalDeCompartilhamentos()
                });

            //CreateMap<Postagem, PostagemDTO>()
            //    .ConstructUsing(postagem => new PostagemDTO()
            //    {
            //        Id = postagem.Id,
            //        UsuarioId = postagem.UsuarioId,
            //        Titulo = postagem.Cabecalho.Titulo,
            //        SubTitulo = postagem.Cabecalho.SubTitulo,
            //        Corpo = postagem.Corpo,
            //        DataCriacao = postagem.DetalhesModificacao.DataCriacao,
            //        DataModificacao = postagem.DetalhesModificacao.DataModificacao
            //    })
            //    .ForMember(dto => dto.Avaliacoes, options => options.MapFrom(source => source.Avaliacoes))
            //    .ForMember(dto => dto.Comentarios, options => options.MapFrom(source => source.Comentarios))
            //    .ForMember(dto => dto.Compartilhamentos, options => options.MapFrom(source => source.Compartilhamentos));

        }

    }

}
