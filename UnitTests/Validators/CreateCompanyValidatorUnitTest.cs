using CommonTestsUtilities.Company;
using FluentAssertions;
using Settrix.Application.Validators.Company;
using Settrix.Comunication.Resources.Company;
using Settrix.Domain.Types;

namespace UnitTests;

public class CreateCompanyValidatorUnitTest
{
    [Fact]
    public void ValidCompany()
    {
        var validator = new CreateCompanyValidator();
        var request = RequestRegisterCompanyBuilder.Build();
        
        var result = validator.Validate(request);
        
        result.IsValid.Should().BeTrue();
    }
    
    [Fact]
    public void InvalidCompany_EmptyName()
    {
        var validator = new CreateCompanyValidator();
        var request = RequestRegisterCompanyBuilder.Build();
        request.Name = String.Empty;
        
        var result = validator.Validate(request);
        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        
        result.IsValid.Should().NotBe(true);
        errors.Should().ContainSingle().And.Contain(e => e == CompanyResource.NAME_CANT_BE_EMPTY);
    }
    
    [Fact]
    public void InvalidCompany_EmptyCNPJ()
    {
        var validator = new CreateCompanyValidator();
        var request = RequestRegisterCompanyBuilder.Build();
        request.Cnpj = String.Empty;
        
        var result = validator.Validate(request);
        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        
        result.IsValid.Should().NotBe(true);
        errors.Should().ContainSingle().And.Contain(e => e == CompanyResource.INVALID_CNPJ);
    }
    
    [Fact]
    public void InvalidCompany_InvalidFunctionType()
    {
        var validator = new CreateCompanyValidator();
        var request = RequestRegisterCompanyBuilder.Build();
        request.Function = (CompanyFunctionType)999;
        
        var result = validator.Validate(request);
        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        
        result.IsValid.Should().NotBe(true);
        errors.Should().ContainSingle().And.Contain(e => e == CompanyResource.UNSUPPORTED_COMPANY_FUNCTION);
    }
}