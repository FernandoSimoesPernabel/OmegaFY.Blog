using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Common.Exceptions;

namespace OmegaFY.Blog.Infra.Exceptions;

public class UnableToCreateUserOnIdentityException : ErrorCodeException
{
    public UnableToCreateUserOnIdentityException() : this(string.Empty) { }

    public UnableToCreateUserOnIdentityException(string message) : base(ApplicationErrorCodes.UNABLE_TO_CREATE_USER_ON_IDENTITY, message) { }
}