﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.Extensions;
using OmegaFY.Blog.WebAPI.Models.Responses;

namespace OmegaFY.Blog.WebAPI.FIlters;

public class ErrorHandlerExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        string erroCode = context.Exception is DomainException domainException ? domainException.ErrorCode : DomainErrorCodes.NOT_DOMAIN_ERROR_CODE;

        ApiResponse response = new ApiResponse(erroCode, context.Exception.GetErrorsMessagesFromInnerExceptions());
        context.Result = new ObjectResult(response) { StatusCode = response.StatusCode() };
    }
}