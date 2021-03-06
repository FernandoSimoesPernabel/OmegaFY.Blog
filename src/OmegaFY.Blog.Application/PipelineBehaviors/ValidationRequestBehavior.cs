﻿using FluentValidation;
using FluentValidation.Results;
using MediatR;
using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.PipelineBehaviors
{

    public class ValidationRequestBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult> where TResult : GenericResult
    {

        private readonly IValidator<TRequest> _validator;

        public ValidationRequestBehavior(IValidator<TRequest> validator)
            => _validator = validator;

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

        private async Task<TResult> ErrosFromValidationFailure(IEnumerable<ValidationFailure> failures)
        {
            TResult result = CreateInstanceOfTResult();

            foreach (ValidationFailure failure in failures)
                result.Criticar(failure.ErrorCode, failure.ErrorMessage);

            return await CreateTaskResult(result);
        }

        private async Task<TResult> ErrorsFromException(string errorCode, string errorMessage)
        {
            TResult result = CreateInstanceOfTResult();
            result.Criticar(errorCode, errorMessage);

            return await CreateTaskResult(result);
        }

        private async Task<TResult> CreateTaskResult(TResult result) => await Task.FromResult(result);

        private TResult CreateInstanceOfTResult() => (TResult)Activator.CreateInstance(typeof(TResult), new object[] { });

    }

}
