using FluentValidation;
using FluentValidation.Results;
using MediatR;
using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Domain.Core.Commands;
using OmegaFY.Blog.Domain.Core.Queries;
using OmegaFY.Blog.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.PipelineBehaviors
{

    public class ValidationRequestBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult>
        where TRequest : ICommandHandler, IQueryHandler
        where TResult : GenericResult<TResult>, ICommandResult, IQueryResult
    {

        private readonly IValidator<TRequest> _validator;

        public ValidationRequestBehavior(IValidator<TRequest> validator) 
            => _validator = validator;

        public Task<TResult> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResult> next)
        {
            try
            {
                ValidationResult validationResult = _validator.Validate(request);
                return validationResult.IsValid ? ErrosFromValidationFailure(validationResult.Errors) : next();
            }
            catch (DomainException domainException)
            {
                return ErrorsFromException(domainException.ErrorCode, domainException.Message);
            }
            catch (Exception ex)
            {
                return ErrorsFromException(DomainErrorCodes.NOT_DOMAIN_ERROR_CODE, ex.Message);
            }
        }

        private Task<TResult> ErrosFromValidationFailure(IEnumerable<ValidationFailure> failures)
        {
            GenericResult<TResult> result = new GenericResult<TResult>();

            foreach (ValidationFailure failure in failures)
                result.Criticar(failure.ErrorCode, failure.ErrorMessage);

            return CreateTaskResult(result);
        }

        private Task<TResult> ErrorsFromException(string errorCode, string errorMessage)
        {
            GenericResult<TResult> result = new GenericResult<TResult>();
            result.Criticar(errorCode, errorMessage);

            return CreateTaskResult(result);
        }

        private Task<TResult> CreateTaskResult(GenericResult<TResult> result) => Task.FromResult(result as TResult);

    }

}
