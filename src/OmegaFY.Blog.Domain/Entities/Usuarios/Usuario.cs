using OmegaFY.Blog.Domain.Core.Entities;
using OmegaFY.Blog.Domain.ValueObjects.Shared;
using OmegaFY.Blog.Domain.ValueObjects.Usuarios;

namespace OmegaFY.Blog.Domain.Entities.Usuario
{

    public class Usuario : Entity, IAggregateRoot<Usuario>
    {

        public Login Login { get; }

        public DetalhesModificacao DetalhesModificacao { get; }

        public Usuario(Login login)
        {
            UsuarioId = Id;
            Login = login;
            //Senha = senha;
            //Email = email;
            DetalhesModificacao = new DetalhesModificacao();
        }

    }

}
