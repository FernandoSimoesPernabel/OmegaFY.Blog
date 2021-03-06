﻿using OmegaFY.Blog.Common.Constantes;

namespace OmegaFY.Blog.Domain.Exceptions
{

    public class DomainArgumentException : DomainException
    {
        public DomainArgumentException(string message) : this(DomainErrorCodes.DOMAIN_ARGUMENT_ERROR_CODE, message) { }

        public DomainArgumentException(string erroCode, string message) : base(message) => ErrorCode = erroCode;

    }

}
