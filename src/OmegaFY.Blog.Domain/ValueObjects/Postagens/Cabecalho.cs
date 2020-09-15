using Flunt.Validations;
using OmegaFY.Blog.Domain.Extensions;

namespace OmegaFY.Blog.Domain.ValueObjects.Postagens
{

    public class Cabecalho : ValueObject
    {

        public string Titulo { get; }

        public string SubTitulo { get; }

        public Cabecalho(string titulo, string subTitulo)
        {
            new Contract()
                .ValidarTitulo(titulo)
                .ValidarSubTitulo(subTitulo)
                .EnsureContractIsValid();

            Titulo = titulo;
            SubTitulo = subTitulo;
        }

        public override bool Equals(ValueObject other)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString() => Titulo;

    }

}
