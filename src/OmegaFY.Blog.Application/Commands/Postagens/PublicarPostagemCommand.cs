using MediatR;

using OmegaFY.Blog.Domain.Core.Commands;

namespace OmegaFY.Blog.Application.Commands.Postagens
{

    public class PublicarPostagemCommand : ICommand, IRequest<PublicarPostagemCommandResult>
    {

        public string Titulo { get; set; }

        public string SubTitulo { get; set; }

        public string ConteudoPostagem { get; set; }

    }

}
