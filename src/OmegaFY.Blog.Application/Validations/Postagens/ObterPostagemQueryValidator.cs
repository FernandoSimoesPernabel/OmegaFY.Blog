using FluentValidation;
using OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem;

namespace OmegaFY.Blog.Application.Validations.Postagens
{

    public class ObterPostagemQueryValidator : AbstractValidator<ObterPostagemQuery>
    {

        public ObterPostagemQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
        
    }
   
}
