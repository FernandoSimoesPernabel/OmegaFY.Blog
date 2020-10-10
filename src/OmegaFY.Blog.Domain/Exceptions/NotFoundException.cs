using OmegaFY.Blog.Domain.Core.Constantes;

namespace OmegaFY.Blog.Domain.Exceptions
{

    public class NotFoundException : DomainException
    {
        public NotFoundException(string message) : base(DomainErrorCodes.NOT_FOUND_ERROR_CODE, message) { }
    }

}
