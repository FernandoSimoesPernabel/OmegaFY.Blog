using OmegaFY.Blog.Domain.Core.Results;
using System.Collections.Generic;

namespace OmegaFY.Blog.Application.Base
{

    public class GenericResult<TResult> where TResult : IResult
    {
        private List<ValidationError> _erros { get; }

        public IReadOnlyCollection<ValidationError> Errors => _erros;

        public TResult Data { get; }

        public bool Sucesso { get; }

        public GenericResult(bool sucesso) : this(default, sucesso) { }

        public GenericResult(TResult data, bool sucesso)
        {
            _erros = new List<ValidationError>();

            Data = data;
            Sucesso = sucesso;
        }

        public void Criticar(string codigo, string mensagem) => _erros.Add(new ValidationError(codigo, mensagem));

        public bool Valido() => _erros?.Count == 0;

        public static GenericResult<TResult> ResultSucesso() => new GenericResult<TResult>(true);

        public static GenericResult<TResult> ResultFalha() => new GenericResult<TResult>(false);


    }

}
