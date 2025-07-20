using FluentAssertions;
using CommunTestsUtilities;
using Settrix.Application.Validators;
using Settrix.Comunication.DTO_s.Request;
using Settrix.Comunication.Resources.User;

namespace UnitTests;

public class UserValidatorUnitTest
{
    private RequestRegisterUserJson User {get; set;} = RequestRegisterUserBuilder.Build();
    private RequestNewUserValidator Validator { get; set; } = new();
    
    [Fact]
    public void ValidUser()
    {
        
        var result = Validator.Validate(User);
        
        result.IsValid.Should().BeTrue();
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("             ")]
    public void EmptyName(string name)
    {
        User.Name = name;
        
        var result = Validator.Validate(User);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage == UserResource.INVALID_NAME);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("             ")]
    public void EmptyEmail(string email)
    {
        User.Email = email;
        
        var result = Validator.Validate(User);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage == UserResource.EMPTY_EMAIL);
    }
    
    [Theory]
    [InlineData("exemplo@")]
    [InlineData("@exemplo.com")]
    [InlineData("exemplo.com")]
    public void InvalidEmail(string email)
    {
        User.Email = email;
        
        var result = Validator.Validate(User);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage == UserResource.INVALID_EMAIL);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData(-1)]
    public void InvalidCompanyId(long id)
    {
        User.CompanyId = id;
        
        var result = Validator.Validate(User);
        
        result.IsValid.Should().BeFalse();
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData(-1)]
    public void InvalidCreatedBy(long id)
    {
        User.CreatedBy = id;
        
        var result = Validator.Validate(User);
        
        result.IsValid.Should().BeFalse();
    }
}