using FluentValidation;
using OmegaFY.Blog.Application.Commands.Postagens;

namespace OmegaFY.Blog.Application.Validations.Postagens
{

    public class PublicarPostagemCommandValidator : AbstractValidator<PublicarPostagemCommand>
    {

        public PublicarPostagemCommandValidator()
        {
            RuleFor(x => x.Titulo).NotEmpty();
            RuleFor(x => x.SubTitulo).NotEmpty();
            RuleFor(x => x.ConteudoPostagem).NotEmpty();
        }

    }

}
