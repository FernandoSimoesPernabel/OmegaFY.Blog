using FluentValidation;
using OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensRecentes;

namespace OmegaFY.Blog.Application.Validations.Postagens
{

    public class ListarPostagensRecentesQueryValidator : AbstractValidator<ListarPostagensRecentesQuery>
    {

        public ListarPostagensRecentesQueryValidator()
        {
            RuleFor(x => x.QuantidadeDePostagens).GreaterThanOrEqualTo(1);
            RuleFor(x => x.QuantidadeDePostagens).LessThanOrEqualTo(50);
        }

    }

}
