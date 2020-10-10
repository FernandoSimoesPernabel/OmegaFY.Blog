using OmegaFY.Blog.Domain.Core.Results;
using System.Collections.Generic;

namespace OmegaFY.Blog.Application.Base
{

    public class GenericResult<TResult> where TResult : IResult
    {
        private List<ValidationError> _erros { get; }

        public IReadOnlyCollection<ValidationError> Errors => _erros;

        public GenericResult()
        {
            _erros = new List<ValidationError>();
        }

        public void Criticar(string codigo, string mensagem) => _erros.Add(new ValidationError(codigo, mensagem));

        public bool Valido() => _erros?.Count == 0;

    }

}
