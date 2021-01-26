using FluentValidation;
using OmegaFY.Blog.Application.Commands.Postagens.ComentarPostagem;

namespace OmegaFY.Blog.Application.Validations.Postagens
{

    public class ComentarPostagemCommandValidator : AbstractValidator<ComentarPostagemCommand>
    {

        public ComentarPostagemCommandValidator()
        {

        }

    }

}
