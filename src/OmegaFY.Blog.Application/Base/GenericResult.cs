using OmegaFY.Blog.Application.Commands;
using OmegaFY.Blog.Application.Queries;
using System.Collections.Generic;

namespace OmegaFY.Blog.Application.Base
{

    public class GenericResult<TResult> where TResult : ICommandResult, IQueryResult
    {
        private List<ValidationError> _erros { get; }

        public TResult Data { get; }

        public IReadOnlyCollection<ValidationError> Errors => _erros;

        public GenericResult() : this(default) { }

        public GenericResult(TResult data)
        {
            Data = data;
            _erros = new List<ValidationError>();
        }

        public void Criticar(string codigo, string mensagem) => _erros.Add(new ValidationError(codigo, mensagem));

        public bool Valido() => _erros?.Count == 0;

    }

}
