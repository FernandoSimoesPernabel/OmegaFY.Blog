using OmegaFY.Blog.Domain.Core.Constantes;

namespace OmegaFY.Blog.Domain.Core.Exceptions
{

    public class DomainInvalidOperationException : DomainException
    {

        public DomainInvalidOperationException(string message) : base(DomainErrorCodes.INVALID_OPERATION_ERROR_CODE, message) { }

    }

}
