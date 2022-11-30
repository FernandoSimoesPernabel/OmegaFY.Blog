using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Infra.RateLimiter.Configs;

public record class IpOrUserTokenBucketPolicySettings
{
    public TimeSpan ReplenishmentPeriod { get; set; }

    public int TokenLimit { get; set; }

    public int TokensPerPeriod { get; set; }
}