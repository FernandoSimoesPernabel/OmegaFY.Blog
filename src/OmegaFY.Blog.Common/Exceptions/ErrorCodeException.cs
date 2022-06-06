using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Common.Exceptions;

public abstract class ErrorCodeException : Exception
{
    public string ErrorCode { get; }

    public ErrorCodeException(string erroCode, string message) : base(message) => ErrorCode = erroCode;
}