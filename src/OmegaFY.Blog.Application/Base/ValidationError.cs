namespace OmegaFY.Blog.Application.Base
{

    public class ValidationError
    {

        public string Codigo { get; }

        public string Mensagem { get; }

        public ValidationError(string codigo, string mensagem)
        {
            Codigo = codigo ?? string.Empty;
            Mensagem = mensagem ?? string.Empty;
        }

    }

}
