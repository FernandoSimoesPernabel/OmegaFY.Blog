using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Constantes;

namespace OmegaFY.Blog.Domain.Exceptions;

public abstract class DomainException : ErrorCodeException
{
    public DomainException(string message) : this(DomainErrorCodes.GENERIC_DOMAIN_ERROR_CODE, message) { }

    public DomainException(string erroCode, string message) : base(erroCode, message) { }

}