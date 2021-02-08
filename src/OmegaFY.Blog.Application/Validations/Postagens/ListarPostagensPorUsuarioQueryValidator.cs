using FluentValidation;
using OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensPorUsuario;

namespace OmegaFY.Blog.Application.Validations.Postagens
{

    public class ListarPostagensPorUsuarioQueryValidator : AbstractValidator<ListarPostagensPorUsuarioQuery>
    {

        public ListarPostagensPorUsuarioQueryValidator()
        {
            RuleFor(x => x.UsuarioId).NotEmpty();
            RuleFor(x => x.PagedRequest).NotNull();
        }

    }

}
