using OmegaFY.Blog.Common.Constantes;

namespace OmegaFY.Blog.Domain.Exceptions;

public class DomainInvalidOperationException : DomainException
{
    public DomainInvalidOperationException(string message) : base(ApplicationErrorCodes.INVALID_OPERATION, message) { }
}
