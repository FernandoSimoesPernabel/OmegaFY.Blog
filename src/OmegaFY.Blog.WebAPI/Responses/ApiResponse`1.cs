using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Common.Extensions;

namespace OmegaFY.Blog.WebAPI.Responses;

public class ApiResponse<T>
{
    private readonly List<ValidationError> _errors;

    public bool Succeeded => _errors?.Count == 0;

    public IReadOnlyCollection<ValidationError> Errors => _errors.AsReadOnly();

    public T Data { get; set; }

    public ApiResponse() => _errors = new List<ValidationError>();

    public ApiResponse(T data) : this() => Data = data;

    public ApiResponse(IReadOnlyCollection<ValidationError> errors) : this() => _errors = new List<ValidationError>(errors);

    public ApiResponse(string code, string mesage) : this() => _errors.Add(new ValidationError(code, mesage));

    public int StatusCode()
    {
        if (Succeeded)
            return StatusCodes.Status200OK;

        if (_errors.Any(erro => erro.Code.In(ApplicationErrorCodes.GENERIC_DOMAIN_ERROR,
                                             ApplicationErrorCodes.INVALID_OPERATION,
                                             ApplicationErrorCodes.DOMAIN_ARGUMENT_INVALID,
                                             ApplicationErrorCodes.UNABLE_TO_CREATE_USER_ON_IDENTITY)))
            return StatusCodes.Status400BadRequest;

        if (_errors.Any(erro => erro.Code == ApplicationErrorCodes.NOT_FOUND))
            return StatusCodes.Status404NotFound;

        if (_errors.Any(erro => erro.Code == ApplicationErrorCodes.ENTITY_CONFLICTED))
            return StatusCodes.Status409Conflict;

        if (_errors.Any(erro => erro.Code == ApplicationErrorCodes.UNAUTHORIZED))
            return StatusCodes.Status401Unauthorized;

        return StatusCodes.Status500InternalServerError;
    }
}