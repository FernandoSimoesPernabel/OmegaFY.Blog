using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OmegaFY.Blog.Application.Queries.Pagination;
using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.WebAPI.Models.Responses;

namespace OmegaFY.Blog.WebAPI.FIlters;

public class ApiResponseActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        try
        {
            if (context.Result is ObjectResult result && result.Value is GenericResult genericResult)
            {
                if (genericResult.Failed())
                {
                    ApiResponse response = new ApiResponse(genericResult.Errors());
                    context.Result = new ObjectResult(response) { StatusCode = response.StatusCode() };
                    return;
                }

                result.Value = new ApiResponse(result.Value);
            }
        }
        catch (Exception ex)
        {
            ApiResponse response = new ApiResponse(DomainErrorCodes.NOT_DOMAIN_ERROR_CODE, ex.GetErrorsMessagesFromInnerExceptions());
            context.Result = new ObjectResult(response) { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }
}