using FluentValidation;
using Settrix.Comunication.DTO_s.Request;
using Settrix.Comunication.Resources.User;

namespace Settrix.Application.Validators;

public class RequestNewUserValidator: AbstractValidator<RequestRegisterUserJson>
{
    public RequestNewUserValidator()
    {
        RuleFor(u => u.Name).NotEmpty().WithMessage(UserResource.INVALID_NAME);
        
        RuleFor(u => u.Email)
            .NotEmpty().WithMessage(UserResource.EMPTY_EMAIL)
            .EmailAddress().When(u => !string.IsNullOrWhiteSpace(u.Email), ApplyConditionTo.CurrentValidator).WithMessage(UserResource.INVALID_EMAIL);
        
        RuleFor(u => u.Password).SetValidator(new PasswordValidator<RequestRegisterUserJson>());
        RuleFor(u => u.Role).IsInEnum().WithMessage(UserResource.INVALID_ROLE);
    }
}