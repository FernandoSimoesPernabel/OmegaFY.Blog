using FluentValidation;
using OmegaFY.Blog.Application.Commands.Postagens.AvaliarPostagem;

namespace OmegaFY.Blog.Application.Validations.Postagens
{

    public class AvaliarPostagemCommandValidator : AbstractValidator<AvaliarPostagemCommand>
    {

        public AvaliarPostagemCommandValidator()
        {
            
        }

    }

}
