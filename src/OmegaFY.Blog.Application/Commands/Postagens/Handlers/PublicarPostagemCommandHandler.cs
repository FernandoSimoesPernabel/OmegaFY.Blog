using MediatR;
using OmegaFY.Blog.Domain.Core.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Commands.Postagens.Handlers
{

    public class PublicarPostagemCommandHandler : ICommandHandler, IRequestHandler<PublicarPostagemCommand, PublicarPostagemCommandResult>
    {
        public async Task<PublicarPostagemCommandResult> Handle(PublicarPostagemCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new PublicarPostagemCommandResult());
        }
    }

}
