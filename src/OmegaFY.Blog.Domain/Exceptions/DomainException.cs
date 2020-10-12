using OmegaFY.Blog.Common.Constantes;
using System;

namespace OmegaFY.Blog.Domain.Exceptions
{
    public abstract class DomainException : Exception
    {
        public string ErrorCode { get; set; }

        public DomainException(string message) : this(DomainErrorCodes.GENERIC_DOMAIN_ERROR_CODE, message) { }

        public DomainException(string erroCode, string message) : base(message) => ErrorCode = erroCode;

    }
}
