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
}