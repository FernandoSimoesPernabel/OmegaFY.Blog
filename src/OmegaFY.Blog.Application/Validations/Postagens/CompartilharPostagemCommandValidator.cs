using FluentValidation;
using OmegaFY.Blog.Application.Commands.Postagens.CompartilharPostagem;

namespace OmegaFY.Blog.Application.Validations.Postagens
{

    public class CompartilharPostagemCommandValidator : AbstractValidator<CompartilharPostagemCommand>
    {

        public CompartilharPostagemCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }

    }

}
