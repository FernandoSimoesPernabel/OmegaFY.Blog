using System;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.ValueObjects.Usuarios
{

    public class Login : ValueObject
    {

        public string NomeUsuario { get; private set; }

        public Email Email { get; private set; }

        public Senha Senha { get; private set; }

        public Login(string nomeUsuario, Email email, Senha senha)
        {
            Email = email;
            NomeUsuario = nomeUsuario;
            Senha = senha;
        }

        public override bool Equals(ValueObject other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }

}
