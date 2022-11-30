using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Infra.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid? TryGetUserIdFromClaims(this ClaimsPrincipal claimsPrincipal)
    {
        Guid.TryParse(claimsPrincipal.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value, out Guid userId);
        return userId;
    }

    public static string TryGetEmailFromClaims(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;

    public static bool IsAuthenticated(this ClaimsPrincipal claimsPrincipal) => claimsPrincipal.Identity?.IsAuthenticated is true;
}