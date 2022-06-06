using OmegaFY.Blog.Application.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Commands.Users.RefreshToken;

public class RefreshTokenCommand : CommandMediatRBase<RefreshTokenCommandResult>
{
    public Guid RefreshToken { get; set; }

    public RefreshTokenCommand() { }

    public RefreshTokenCommand(Guid refreshToken)
    {
        RefreshToken = refreshToken;
    }
}