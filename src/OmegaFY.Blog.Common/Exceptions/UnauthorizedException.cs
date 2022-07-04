using OmegaFY.Blog.Common.Constantes;

namespace OmegaFY.Blog.Common.Exceptions;

public class UnauthorizedException : ErrorCodeException
{
    public UnauthorizedException() : this(string.Empty) { }

    public UnauthorizedException(string message) : base(ApplicationErrorCodes.UNAUTHORIZED, message) { }
}