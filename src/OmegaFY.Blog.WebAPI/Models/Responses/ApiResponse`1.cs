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

    public int StatusCode()
    {
        if (_errors.Any(erro => erro.Code.In(DomainErrorCodes.GENERIC_DOMAIN_ERROR_CODE,
                                             DomainErrorCodes.INVALID_OPERATION_ERROR_CODE,
                                             DomainErrorCodes.DOMAIN_ARGUMENT_ERROR_CODE)))
            return StatusCodes.Status400BadRequest;

        if (_errors.Any(erro => erro.Code == DomainErrorCodes.NOT_FOUND_ERROR_CODE))
            return StatusCodes.Status404NotFound;

        if (Succeeded)
            return StatusCodes.Status200OK;

        return StatusCodes.Status500InternalServerError;
    }
}