using Flunt.Validations;
using OmegaFY.Blog.Domain.Extensions;

namespace OmegaFY.Blog.Domain.ValueObjects.Shared
{

    public class Email
    {

        public string Endereco { get; private set; }

        public string Nome { get; private set; }

        public string Provedor { get; private set; }

        public Email(string email)
        {
            new Contract()
                .IsEmail(email, nameof(email), $"O e-mail '{email}' não é um endereço valído.")
                .EnsureContractIsValid();

            Endereco = email;

            int posicaoArroba = email.IndexOf('@');
            Nome = email.Substring(0, posicaoArroba);
            Provedor = email.Substring(posicaoArroba);
        }

    }

}
