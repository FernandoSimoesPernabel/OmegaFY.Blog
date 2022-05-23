using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Infra.Authentication;

internal class HttpContextAccessorUserInformation : IUserInformation
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Guid CurrentRequestUserId { get; }

    public HttpContextAccessorUserInformation(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
}
