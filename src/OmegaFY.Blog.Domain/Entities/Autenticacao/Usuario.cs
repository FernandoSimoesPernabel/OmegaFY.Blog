using OmegaFY.Blog.Domain.Core.Entities;
using OmegaFY.Blog.Domain.ValueObjects.Shared;
using OmegaFY.Blog.Domain.ValueObjects.Autenticacao;

namespace OmegaFY.Blog.Domain.Entities.Autenticacao
{

    public class Usuario : Entity, IAggregateRoot<Usuario>
    {

        public Login Login { get; }

        public DetalhesModificacao DetalhesModificacao { get; }

        public Usuario(Login login)
        {
            Login = login;
            DetalhesModificacao = new DetalhesModificacao();
        }

    }

}
