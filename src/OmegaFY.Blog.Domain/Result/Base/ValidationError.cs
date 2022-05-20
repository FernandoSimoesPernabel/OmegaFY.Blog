namespace OmegaFY.Blog.Domain.Result.Base;

public class ValidationError
{

    public string Code { get; }

    public string Message { get; }

    public ValidationError(string code, string message)
    {
        Code = code ?? string.Empty;
        Message = message ?? string.Empty;
    }

}
