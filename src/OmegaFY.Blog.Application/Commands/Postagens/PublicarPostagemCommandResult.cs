using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Domain.Core.Commands;
using System;

namespace OmegaFY.Blog.Application.Commands.Postagens
{

    public class PublicarPostagemCommandResult : GenericResult, ICommandResult
    {

        public Guid Id { get; private set; }

        public PublicarPostagemCommandResult(Guid id)
        {
            Id = id;
        }

    }

}