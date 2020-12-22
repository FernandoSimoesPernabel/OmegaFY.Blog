using Microsoft.AspNetCore.Http;
using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Common.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace OmegaFY.Blog.WebAPI.Requests
{

    public class ApiResponse : ApiResponse<object>
    {
        //private List<ValidationError> _erros { get; set; }

        //public bool Sucesso => _erros?.Count == 0;

        //public IReadOnlyCollection<ValidationError> Erros => _erros.AsReadOnly();

        //public object Data { get; set; }

        public ApiResponse() : base() { }

        public ApiResponse(object data) : base(data) { }

        public ApiResponse(IReadOnlyCollection<ValidationError> erros) : base(erros) { }

        public ApiResponse(string codigo, string mensagem) : base(codigo, mensagem) { }

        //public int StatusCode()
        //{
        //    if (_erros.Any(erro => erro.Codigo.In(DomainErrorCodes.GENERIC_DOMAIN_ERROR_CODE,
        //                                          DomainErrorCodes.INVALID_OPERATION_ERROR_CODE,
        //                                          DomainErrorCodes.DOMAIN_ARGUMENT_ERROR_CODE)))
        //        return StatusCodes.Status400BadRequest;

        //    if (_erros.Any(erro => erro.Codigo == DomainErrorCodes.NOT_FOUND_ERROR_CODE))
        //        return StatusCodes.Status404NotFound;

        //    if (Sucesso)
        //        return StatusCodes.Status200OK;

        //    return StatusCodes.Status500InternalServerError;
        //}

    }

}
