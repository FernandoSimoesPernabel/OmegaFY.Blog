using OmegaFY.Blog.Domain.Result.Base;

namespace OmegaFY.Blog.WebAPI.Models.Responses;

public class ApiResponse : ApiResponse<object>
{
    public ApiResponse() : base() { }

    public ApiResponse(object data) : base(data) { }

    public ApiResponse(IReadOnlyCollection<ValidationError> erros) : base(erros) { }

    public ApiResponse(string codigo, string mensagem) : base(codigo, mensagem) { }
}
