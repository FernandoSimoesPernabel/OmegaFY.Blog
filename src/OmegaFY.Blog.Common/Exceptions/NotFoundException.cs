using OmegaFY.Blog.Common.Constantes;

namespace OmegaFY.Blog.Common.Exceptions;

public class NotFoundException : ErrorCodeException
{
    public NotFoundException() : this(string.Empty) { }

    public NotFoundException(string message) : base(ApplicationErrorCodes.NOT_FOUND, message) { }
}