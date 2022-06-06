using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Infra.Constants;

namespace OmegaFY.Blog.Infra.Exceptions;

public class UnauthorizedException : ErrorCodeException
{
    public UnauthorizedException() : this(string.Empty) { }

    public UnauthorizedException(string message) : base(InfraErrorCodes.UNAUTHORIZED_ERROR_CODE, message) { }
}
