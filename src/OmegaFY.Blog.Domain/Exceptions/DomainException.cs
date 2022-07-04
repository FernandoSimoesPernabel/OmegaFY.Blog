using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Common.Exceptions;

namespace OmegaFY.Blog.Domain.Exceptions;

public abstract class DomainException : ErrorCodeException
{
    public DomainException(string message) : this(ApplicationErrorCodes.GENERIC_DOMAIN_ERROR, message) { }

    public DomainException(string erroCode, string message) : base(erroCode, message) { }

}