namespace OmegaFY.Blog.Domain.ValueObjects.Shared
{

    public class Corpo : ValueObject
    {

        public string Conteudo { get; }

        public Corpo(string conteudo)
        {
            Conteudo = conteudo;
        }

        public override bool Equals(ValueObject other)
        {
            if (!(other is Corpo corpo)) return false;
            return string.Equals(Conteudo, corpo?.Conteudo, System.StringComparison.CurrentCultureIgnoreCase);
        }

        public override string ToString() => Conteudo;

        public static implicit operator string(Corpo corpo) => corpo?.Conteudo;

        public static implicit operator Corpo(string mensagem) => new Corpo(mensagem);

    }

}
