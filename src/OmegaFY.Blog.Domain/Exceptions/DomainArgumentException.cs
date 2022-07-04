using OmegaFY.Blog.Common.Constantes;

namespace OmegaFY.Blog.Domain.Exceptions;

public class DomainArgumentException : DomainException
{
    public DomainArgumentException(string message) : this(ApplicationErrorCodes.DOMAIN_ARGUMENT_INVALID, message) { }

    public DomainArgumentException(string erroCode, string message) : base(message) => ErrorCode = erroCode;
}
