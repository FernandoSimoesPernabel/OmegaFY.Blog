using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Infra.Constants;

namespace OmegaFY.Blog.Infra.Exceptions;

public class UnableToCreateUserOnIdentityException : ErrorCodeException
{
    public UnableToCreateUserOnIdentityException() : this(string.Empty) { }

    public UnableToCreateUserOnIdentityException(string message) : base(InfraErrorCodes.UNABLE_TO_CREATE_USER_ON_IDENTITY, message) { }
}