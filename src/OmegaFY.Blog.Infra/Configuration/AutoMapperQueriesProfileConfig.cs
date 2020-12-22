using AutoMapper;
using OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem;
using OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem.Results;
using OmegaFY.Blog.Domain.Entities.Comentarios;
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
                .ConstructUsing(result => new ObterPostagemQueryResult()
                {
                    Id = result.Id,
                    UsuarioId = result.UsuarioId,
                    Titulo = result.Cabecalho.Titulo,
                    SubTitulo = result.Cabecalho.SubTitulo,
                    Corpo = result.Corpo,
                    DataCriacao = result.DetalhesModificacao.DataCriacao,
                    DataModificacao = result.DetalhesModificacao.DataModificacao
                })
                .ForMember(result => result.Avaliacoes, options => options.MapFrom(source => source.Avaliacoes))
                .ForMember(result => result.Comentarios, options => options.MapFrom(source => source.Comentarios))
                .ForMember(result => result.Compartilhamentos, options => options.MapFrom(source => source.Compartilhamentos));

            CreateMap<Avaliacao, ObterPostagemAvaliacoesQuery>();

            CreateMap<Comentario, ObterPostagemComentariosQuery>();

            CreateMap<Compartilhamento, ObterPostagemCompartilhamentosQuery>();

        }

    }

}
