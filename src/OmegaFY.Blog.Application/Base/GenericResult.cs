using OmegaFY.Blog.Domain.Core.Results;
using System.Collections.Generic;

namespace OmegaFY.Blog.Application.Base
{

    public abstract class GenericResult : IResult
    {
        private List<ValidationError> _erros { get; }

        public GenericResult()
        {
            _erros = new List<ValidationError>();
        }

        public void Criticar(string codigo, string mensagem) => _erros.Add(new ValidationError(codigo, mensagem));

        public bool Sucesso() => _erros?.Count == 0;

        public bool Falha() => !Sucesso();

        public IReadOnlyCollection<ValidationError> Errors() => _erros.AsReadOnly();

    }

}
