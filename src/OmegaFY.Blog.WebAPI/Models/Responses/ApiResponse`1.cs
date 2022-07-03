using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Domain.Constantes;

namespace OmegaFY.Blog.WebAPI.Models.Responses;

public class ApiResponse<T>
{
    private readonly List<ValidationError> _errors;

    public bool Succeeded => _errors?.Count == 0;

    public IReadOnlyCollection<ValidationError> Erros => _errors.AsReadOnly();

    public T Data { get; set; }

    public ApiResponse() => _errors = new List<ValidationError>();

    public ApiResponse(T data) : this() => Data = data;

    public ApiResponse(IReadOnlyCollection<ValidationError> errors) : this() => _errors = new List<ValidationError>(errors);

    public ApiResponse(string code, string mesage) : this() => _errors.Add(new ValidationError(code, mesage));

    //TODO pensar melhor nisso do codigo, provavelmente trocar para texto mesmo (NotFound, BadRequest).
    public int StatusCode()
    {
        if (Succeeded)
            return StatusCodes.Status200OK;

        if (_errors.Any(erro => erro.Code == "400"))
            return StatusCodes.Status400BadRequest;

        if (_errors.Any(erro => erro.Code == "404"))
            return StatusCodes.Status404NotFound;

        if (_errors.Any(erro => erro.Code == "409"))
            return StatusCodes.Status409Conflict;

        if (_errors.Any(erro => erro.Code == "401"))
            return StatusCodes.Status401Unauthorized;

        return StatusCodes.Status500InternalServerError;
    }
}