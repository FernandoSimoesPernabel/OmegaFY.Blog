using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Infra.Constants;

namespace OmegaFY.Blog.Infra.Exceptions;

public class ConflictedException : ErrorCodeException
{
    public ConflictedException() : this(string.Empty) { }

    public ConflictedException(string message) : base(InfraErrorCodes.ENTITY_CONFLICTED_ERROR_CODE, message) { }
}