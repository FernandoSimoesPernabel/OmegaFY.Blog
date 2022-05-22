using FluentValidation;
using FluentValidation.Results;
using MediatR;
using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Exceptions;

namespace OmegaFY.Blog.Application.PipelineBehaviors;

public class ValidationRequestBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult> where TRequest : IRequest<TResult> where TResult : GenericResult
{
    private readonly IValidator<TRequest> _validator;

    public ValidationRequestBehavior(IValidator<TRequest> validator) => _validator = validator;

    public async Task<TResult> Handle(TRequest request,
                                      CancellationToken cancellationToken,
                                      RequestHandlerDelegate<TResult> next)
    {
        try
        {
            ValidationResult validationResult = _validator.Validate(request);
            return !validationResult.IsValid ? await ErrosFromValidationFailure(validationResult.Errors) : await next();
        }
        catch (DomainException domainException)
        {
            return await ErrorsFromException(domainException.ErrorCode, domainException.GetErrorsMessagesFromInnerExceptions());
        }
        catch (Exception ex)
        {
            return await ErrorsFromException(DomainErrorCodes.NOT_DOMAIN_ERROR_CODE, ex.GetErrorsMessagesFromInnerExceptions());
        }
    }

    private static async Task<TResult> ErrosFromValidationFailure(IEnumerable<ValidationFailure> failures)
    {
        TResult result = CreateInstanceOfTResult();

        foreach (ValidationFailure failure in failures)
            result.AddError(failure.ErrorCode, failure.ErrorMessage);

        return await result.ToTaskResult();
    }

    private static async Task<TResult> ErrorsFromException(string errorCode, string errorMessage)
    {
        TResult result = CreateInstanceOfTResult();
        result.AddError(errorCode, errorMessage);

        return await result.ToTaskResult();
    }

    private static TResult CreateInstanceOfTResult() => (TResult)Activator.CreateInstance(typeof(TResult), Array.Empty<object>());
}