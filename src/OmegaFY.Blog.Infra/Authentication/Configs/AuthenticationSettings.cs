﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Infra.Authentication.Configs;

internal class AuthenticationSettings
{
    public bool PasswordRequireDigit { get; set; }

    public bool PasswordRequireLowercase { get; set; }

    public bool PasswordRequireNonAlphanumeric { get; set; }

    public bool PasswordRequireUppercase { get; set; }

    public byte PasswordMinRequiredLength { get; set; }

    public byte PasswordRequiredUniqueChars { get; set; }

    public TimeSpan DefaultLockoutTimeSpan { get; set; }

    public byte MaxFailedAccessAttempts { get; set; }

    public bool RequireUniqueEmail { get; set; }

    public bool RequireConfirmedEmail { get; set; }

    public bool RequireConfirmedAccount { get; set; }
}