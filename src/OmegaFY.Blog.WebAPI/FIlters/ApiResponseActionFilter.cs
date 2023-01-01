using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.WebAPI.Responses;

namespace OmegaFY.Blog.WebAPI.FIlters;

public class ApiResponseActionFilter : IActionFilter
{
    private readonly IHostEnvironment _environment;

    public ApiResponseActionFilter(IHostEnvironment environment) => _environment = environment;

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
            ApiResponse response = new ApiResponse(ApplicationErrorCodes.NOT_DOMAIN_ERROR, ex.GetSafeErrorMessageWhenInProd(_environment.IsDevelopment()));
            context.Result = new ObjectResult(response) { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }
}