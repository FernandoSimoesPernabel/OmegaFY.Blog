namespace OmegaFY.Blog.Common.Exceptions;

public abstract class ErrorCodeException : Exception
{
    public string ErrorCode { get; init; }

    public ErrorCodeException(string erroCode, string message) : base(message) => ErrorCode = erroCode;
}