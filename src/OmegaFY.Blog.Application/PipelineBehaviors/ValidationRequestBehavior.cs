using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Hosting;
using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Exceptions;

namespace OmegaFY.Blog.Application.PipelineBehaviors;

public class ValidationRequestBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult> where TRequest : IRequest<TResult> where TResult : GenericResult
{
    private readonly IValidator<TRequest> _validator;

    private readonly IHostEnvironment _environment;

    public ValidationRequestBehavior(IValidator<TRequest> validator, IHostEnvironment environment)
    {
        _validator = validator;
        _environment = environment;
    }

    public async Task<TResult> Handle(TRequest request,
                                      CancellationToken cancellationToken,
                                      RequestHandlerDelegate<TResult> next)
    {
        try
        {
            ValidationResult validationResult = _validator.Validate(request);
            return !validationResult.IsValid ? ErrosFromValidationFailure(validationResult.Errors) : await next();
        }
        catch (ErrorCodeException errorCodeException)
        {
            return ErrorsFromException(errorCodeException.ErrorCode, errorCodeException.GetErrorsMessagesFromInnerExceptions());
        }
        catch (Exception ex)
        {
            if (_environment.IsDevelopment())
                return ErrorsFromException(DomainErrorCodes.NOT_DOMAIN_ERROR_CODE, ex.GetErrorsMessagesFromInnerExceptions());

            return ErrorsFromException(DomainErrorCodes.NOT_DOMAIN_ERROR_CODE, ""); //TODO
        }
    }

    private static TResult ErrosFromValidationFailure(IEnumerable<ValidationFailure> failures)
    {
        TResult result = CreateInstanceOfTResult();

        foreach (ValidationFailure failure in failures)
            result.AddError(failure.ErrorCode, failure.ErrorMessage);

        return result;
    }

    private static TResult ErrorsFromException(string errorCode, string errorMessage)
    {
        TResult result = CreateInstanceOfTResult();
        result.AddError(errorCode, errorMessage);

        return result;
    }

    private static TResult CreateInstanceOfTResult() => (TResult)Activator.CreateInstance(typeof(TResult));
}