using FluentValidation;
using Settrix.Comunication.DTO_s.Request.Company;
using Settrix.Comunication.Resources.Company;

namespace Settrix.Application.Validators.Company;

public class CreateCompanyValidator : AbstractValidator<RequestRegisterCompanyJson>
{
    public CreateCompanyValidator()
    {
        RuleFor(company => company.Name)
            .NotEmpty().WithMessage(CompanyResource.NAME_CANT_BE_EMPTY);
        RuleFor(company => company.Cnpj)
            .MinimumLength(14).WithMessage(CompanyResource.INVALID_CNPJ)
            .MaximumLength(18).WithMessage(CompanyResource.INVALID_CNPJ);
        RuleFor(company => company.Function)
            .IsInEnum()
            .When(
                company => !string.IsNullOrWhiteSpace(company.Function.ToString()),
                ApplyConditionTo.CurrentValidator
            )
            .WithMessage(CompanyResource.UNSUPPORTED_COMPANY_FUNCTION);
    }
}