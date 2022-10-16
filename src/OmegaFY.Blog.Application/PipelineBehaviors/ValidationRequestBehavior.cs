using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Hosting;
using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Common.Extensions;

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

    public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        try
        {
            ValidationResult validationResult = _validator.Validate(request);
            return !validationResult.IsValid ? ErrosFromValidationFailure(validationResult.Errors) : await next();
        }
        catch (ErrorCodeException errorCodeException)
        {
            return ErrorsFromException(errorCodeException.ErrorCode, errorCodeException.Message);
        }
        catch (Exception ex)
        {
            return ErrorsFromException(ApplicationErrorCodes.NOT_DOMAIN_ERROR, ex.GetSafeErrorMessageWhenInProd(_environment.IsDevelopment()));
        }
    }

    private static TResult ErrosFromValidationFailure(IEnumerable<ValidationFailure> failures)
    {
        TResult result = CreateInstanceOfTResult();

        foreach (ValidationFailure failure in failures)
            result.AddError(ApplicationErrorCodes.DOMAIN_ARGUMENT_INVALID, failure.ErrorMessage);

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