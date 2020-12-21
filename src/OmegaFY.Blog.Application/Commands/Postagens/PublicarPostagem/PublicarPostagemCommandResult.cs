using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Domain.Core.Commands;
using System;

namespace OmegaFY.Blog.Application.Commands.Postagens.PublicarPostagem
{

    public class PublicarPostagemCommandResult : GenericResult, ICommandResult
    {

        public Guid Id { get; set; }

        public Guid UsuarioId { get; set; }

        public string Titulo { get; set; }

        public string SubTitulo { get; set; }

        public string Corpo { get; set; }

        public DateTime DataCriacao { get; set; }

        public PublicarPostagemCommandResult() : base() { }

        public PublicarPostagemCommandResult(Guid id,
                                             Guid usuarioId,
                                             string titulo,
                                             string subTitulo,
                                             string corpo,
                                             DateTime dataCriacao)
        {
            Id = id;
            UsuarioId = usuarioId;
            Titulo = titulo;
            SubTitulo = subTitulo;
            Corpo = corpo;
            DataCriacao = dataCriacao;
        }

    }

}