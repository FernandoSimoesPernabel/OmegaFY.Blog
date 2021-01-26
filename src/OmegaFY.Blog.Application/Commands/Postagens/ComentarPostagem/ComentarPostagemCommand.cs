using OmegaFY.Blog.Application.Commands.Base;
using System;

namespace OmegaFY.Blog.Application.Commands.Postagens.ComentarPostagem
{

    public class ComentarPostagemCommand : CommandMediatRBase<ComentarPostagemCommandResult>
    {

        public Guid Id { get; set; }

        public string Comentario { get; set; }

        public ComentarPostagemCommand() { }

        public ComentarPostagemCommand(Guid id, string comentario)
        {
            Id = id;
            Comentario = comentario;
        }

    }

}
