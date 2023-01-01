using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.WebAPI.Responses;

namespace OmegaFY.Blog.WebAPI.FIlters;

public class ErrorHandlerExceptionFilter : IExceptionFilter
{
    private readonly IHostEnvironment _environment;

    public ErrorHandlerExceptionFilter(IHostEnvironment environment) => _environment = environment;

    public void OnException(ExceptionContext context)
    {
        string erroCode = context.Exception is ErrorCodeException errorCodeException ? errorCodeException.ErrorCode : ApplicationErrorCodes.NOT_DOMAIN_ERROR;

        ApiResponse response = new ApiResponse(erroCode, context.Exception.GetSafeErrorMessageWhenInProd(_environment.IsDevelopment()));
        context.Result = new ObjectResult(response) { StatusCode = response.StatusCode() };
    }
}