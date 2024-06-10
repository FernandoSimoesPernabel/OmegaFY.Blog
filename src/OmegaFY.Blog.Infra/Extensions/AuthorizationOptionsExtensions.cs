using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using OmegaFY.Blog.Infra.Authentication.Policies;

namespace OmegaFY.Blog.Infra.Extensions;

public static class AuthorizationOptionsExtensions
{
    public static void AddBearerJwtPolicy(this AuthorizationOptions auth)
        => auth.AddPolicy(
            PoliciesNamesConstants.BEARER_JWT_POLICY,
            new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                .RequireAuthenticatedUser()
                .Build());
}