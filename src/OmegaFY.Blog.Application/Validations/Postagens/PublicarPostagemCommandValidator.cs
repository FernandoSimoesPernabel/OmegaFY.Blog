using FluentValidation;
using OmegaFY.Blog.Application.Commands.Postagens.PublicarPostagem;
using OmegaFY.Blog.Common.Constantes;

namespace OmegaFY.Blog.Application.Validations.Postagens
{

    public class PublicarPostagemCommandValidator : AbstractValidator<PublicarPostagemCommand>
    {

        public PublicarPostagemCommandValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty()
                .Length(PostagensConstantes.TAMANHO_MIN_TITULO, PostagensConstantes.TAMANHO_MAX_TITULO);
            
            RuleFor(x => x.SubTitulo)
                .NotEmpty()
                .Length(PostagensConstantes.TAMANHO_MIN_SUB_TITULO, PostagensConstantes.TAMANHO_MAX_SUB_TITULO);
            
            RuleFor(x => x.ConteudoPostagem)
                .NotEmpty()
                .Length(PostagensConstantes.TAMANHO_MIN_CORPO, PostagensConstantes.TAMANHO_MAX_CORPO);
        }

    }

}
