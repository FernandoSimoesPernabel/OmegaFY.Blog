using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Application.Queries.Pagination;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Extensions;
using OmegaFY.Blog.WebAPI.Models.Responses;

namespace OmegaFY.Blog.WebAPI.FIlters;

public class ApiResponseActionFilter : IActionFilter
{

    public void OnActionExecuting(ActionExecutingContext context)
    {

    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        try
        {
            ChangeToApiResponse(context);
        }
        catch (Exception ex)
        {
            ApiResponse response = new ApiResponse(DomainErrorCodes.NOT_DOMAIN_ERROR_CODE, ex.GetErrorsMessagesFromInnerExceptions());
            context.Result = new ObjectResult(response) { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }

    private void ChangeToApiResponse(ActionExecutedContext context)
    {
        if (context.Result is ObjectResult result && result.Value is GenericResult genericResult)
        {
            if (genericResult.Failed())
            {
                ApiResponse response = new ApiResponse(genericResult.Errors());
                context.Result = new ObjectResult(response) { StatusCode = response.StatusCode() };
            }
            else
            {
                AddPaginationHeaderInformationIfPageResponse(result, context.HttpContext.Response.Headers);
                result.Value = new ApiResponse(result.Value);
            }

        }
    }

    private void AddPaginationHeaderInformationIfPageResponse(ObjectResult result, IHeaderDictionary headers)
    {
        if (result.Value is PagedResult pagedResult)
            AddPaginationHeader(headers, pagedResult);
    }

    private static void AddPaginationHeader(IHeaderDictionary headers, PagedResult pagedResult)
        => headers.Add(HttpHeadersConstantes.HTTP_PAGINATION_HEADER, pagedResult.PaginationInformation().ToJson());

}
