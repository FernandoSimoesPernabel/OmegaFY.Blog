using OmegaFY.Blog.Common.Constantes;

namespace OmegaFY.Blog.Domain.Exceptions
{

    public class DomainInvalidOperationException : DomainException
    {

        public DomainInvalidOperationException(string message) : base(DomainErrorCodes.INVALID_OPERATION_ERROR_CODE, message) { }

    }

}
