using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;
using Settrix.Comunication.Resources.User;

namespace Settrix.Application.Validators;

public partial class PasswordValidator<T> : PropertyValidator<T, string>
{
    public override string Name { get; } = "PasswordValidator";

    public override bool IsValid(ValidationContext<T> context, string password)
    {
        var errors = 0;
        if (string.IsNullOrWhiteSpace(password))
        {
            context.AddFailure(PasswordResource.EMPTY_PASSWORD);
            errors++;
        }
        else
        {
            if (password.Length < 8)
            {
                context.AddFailure( PasswordResource.SHORT_PASSWORD);
                errors++;
            }
            if (!UpperCaseLetter().IsMatch(password))
            {
                context.AddFailure( PasswordResource.UPPER_CASE_LETTER);
                errors++;
            }
            if (!LowerCaseLetter().IsMatch(password))
            {
                context.AddFailure( PasswordResource.LOWER_CASE_LETTER);
                errors++;
            }
            if (!SpecialSimbols().IsMatch(password))
            {
                context.AddFailure(PasswordResource.SPECIAL_SYMBOLS);
                errors++;
            }
        }

        if (errors == 0) return true;
        
        return false;

    }

    [GeneratedRegex(@"[A-Z]+")]
    private static partial Regex UpperCaseLetter();
    [GeneratedRegex(@"[a-z]+")]
    private static partial Regex LowerCaseLetter();
    [GeneratedRegex(@"[\!\@\#\$\%]+")]
    private static partial Regex SpecialSimbols();
}