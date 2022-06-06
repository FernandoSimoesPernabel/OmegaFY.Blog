using OmegaFY.Blog.Application.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Commands.Users.Logoff;

public class LogoffCommand : CommandMediatRBase<LogoffCommandResult>
{
    public Guid RefreshToken { get; set; }

    public LogoffCommand() { }

    public LogoffCommand(Guid refreshToken)
    {
        RefreshToken = refreshToken;
    }
}