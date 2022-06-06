using FluentValidation;
using OmegaFY.Blog.Application.Commands.Users.Logoff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Validations.Commands.Users;

public class LogoffCommandValidator : AbstractValidator<LogoffCommand>
{
    public LogoffCommandValidator()
    {

    }
}