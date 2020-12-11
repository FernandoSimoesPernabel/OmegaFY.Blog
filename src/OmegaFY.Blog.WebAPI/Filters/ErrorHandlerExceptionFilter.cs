using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.WebAPI.Requests;

namespace OmegaFY.Blog.WebAPI.Filters
{

    public class ErrorHandlerExceptionFilter : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            string erroCode = DomainErrorCodes.NOT_DOMAIN_ERROR_CODE;

            if (context.Exception is DomainException domainException)
                erroCode = domainException.ErrorCode;

            ApiResponse response = new ApiResponse(erroCode, context.Exception.Message);
            context.Result = new ObjectResult(response) { StatusCode = response.StatusCode() };
        }

    }

}
