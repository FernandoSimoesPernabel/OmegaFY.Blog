using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Common.Enums;
using System;

namespace OmegaFY.Blog.Application.Commands.Postagens.AvaliarPostagem
{

    public class AvaliarPostagemCommand : CommandMediatRBase<AvaliarPostagemCommandResult>
    {

        public Guid Id { get; set; }

        public Estrelas Estrelas { get; set; }

        public AvaliarPostagemCommand() { }

        public AvaliarPostagemCommand(Guid id, Estrelas estrelas)
        {
            Id = id;
            Estrelas = estrelas;
        }

    }

}
