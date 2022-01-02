using OmegaFY.Blog.Domain.Constantes;

namespace OmegaFY.Blog.Domain.Exceptions;

public class NotFoundException : DomainException
{
    public NotFoundException(string message) : base(DomainErrorCodes.NOT_FOUND_ERROR_CODE, message) { }
}