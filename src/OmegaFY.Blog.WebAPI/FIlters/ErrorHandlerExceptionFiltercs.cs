using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.WebAPI.Models.Responses;

namespace OmegaFY.Blog.WebAPI.FIlters;

public class ErrorHandlerExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        string erroCode = context.Exception is ErrorCodeException errorCodeException ? errorCodeException.ErrorCode : ApplicationErrorCodes.NOT_DOMAIN_ERROR;

        ApiResponse response = new ApiResponse(erroCode, context.Exception.GetErrorsMessagesFromInnerExceptions());
        context.Result = new ObjectResult(response) { StatusCode = response.StatusCode() };
    }
}
