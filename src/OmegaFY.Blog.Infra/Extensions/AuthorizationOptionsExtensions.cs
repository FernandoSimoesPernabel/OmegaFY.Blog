using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using OmegaFY.Blog.Infra.Authentication.Policies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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