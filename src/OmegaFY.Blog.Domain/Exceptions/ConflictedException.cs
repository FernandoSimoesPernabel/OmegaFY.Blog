using OmegaFY.Blog.Domain.Constantes;

namespace OmegaFY.Blog.Domain.Exceptions;

public class ConflictedException : DomainException
{
    public ConflictedException() : this(string.Empty) { }

    public ConflictedException(string message) : base(DomainErrorCodes.ENTITY_CONFLICTED_ERROR_CODE, message) { }
}