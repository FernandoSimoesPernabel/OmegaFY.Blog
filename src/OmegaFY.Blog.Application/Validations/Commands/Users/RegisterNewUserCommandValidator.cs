using FluentValidation;
using Microsoft.Extensions.Options;
using OmegaFY.Blog.Application.Commands.Users.RegisterNewUser;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Infra.Authentication.Configs;

namespace OmegaFY.Blog.Application.Validations.Commands.Users;

public class RegisterNewUserCommandValidator : AbstractValidator<RegisterNewUserCommand>
{
    public RegisterNewUserCommandValidator(IOptions<AuthenticationSettings> authenticationOptions)
    {
        AuthenticationSettings authenticationSettings = authenticationOptions.Value;

        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(UserConstants.MAX_EMAIL_LENGTH);

        RuleFor(x => x.DisplayName).NotEmpty().Length(UserConstants.MIN_DISPLAY_NAME_LENGTH, UserConstants.MAX_DISPLAY_NAME_LENGTH);

        RuleFor(x => x.Password)
            .NotEmpty()
            .Length(authenticationSettings.PasswordMinRequiredLength, authenticationSettings.PasswordMaxRequiredLength)
            .Custom((password, context) =>
            {
                char[] passwordAsChars = password.ToCharArray();

                if (authenticationSettings.PasswordRequireDigit && passwordAsChars.Any(c => char.IsDigit(c)))
                    context.AddFailure("");

                if (authenticationSettings.PasswordRequireLowercase && passwordAsChars.Any(c => char.IsLower(c)))
                    context.AddFailure("");

                if (authenticationSettings.PasswordRequireUppercase && passwordAsChars.Any(c => char.IsUpper(c)))
                    context.AddFailure("");

                if (authenticationSettings.PasswordRequireNonAlphanumeric && passwordAsChars.Any(c => !char.IsLetterOrDigit(c)))
                    context.AddFailure("");

                if (authenticationSettings.PasswordRequiredUniqueChars > 0)
                {
                    IEnumerable<char> distinctCharacteres = passwordAsChars.Distinct();

                    if (distinctCharacteres.Count() == authenticationSettings.PasswordRequiredUniqueChars)
                        context.AddFailure("");
                }
            });
    }
}