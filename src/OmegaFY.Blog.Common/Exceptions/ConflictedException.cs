using OmegaFY.Blog.Common.Constantes;

namespace OmegaFY.Blog.Common.Exceptions;

public class ConflictedException : ErrorCodeException
{
    public ConflictedException() : this(string.Empty) { }

    public ConflictedException(string message) : base(ApplicationErrorCodes.ENTITY_CONFLICTED, message) { }
}