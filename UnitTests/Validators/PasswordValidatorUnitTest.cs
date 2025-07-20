using FluentAssertions;
using FluentValidation;
using Settrix.Application.Validators;
using Settrix.Comunication.DTO_s.Request;

namespace UnitTests;

public class PasswordValidatorUnitTest
{
    [Fact]
    public void ValidPassword()
    {
        string password = "Mud@r123";
        var validator = new PasswordValidator<RequestRegisterUserJson>();
        var context = new ValidationContext<RequestRegisterUserJson>(
            new RequestRegisterUserJson()
        );

        var result = validator.IsValid(context, password);
        
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("             ")]
    [InlineData("Mud@r")] //Length < 8 
    [InlineData("mud@r123")] //Lowercase only
    [InlineData("MUD@R1234")] //Uppercase only
    [InlineData("123456789")] //Number only
    [InlineData("Mudar1234")] //None Symbol
    public void InvalidPassword(string password)
    {
        var validator = new PasswordValidator<RequestRegisterUserJson>();
        var context = new ValidationContext<RequestRegisterUserJson>(
            new RequestRegisterUserJson()
        );

        var result = validator.IsValid(context, password);
        
        result.Should().BeFalse();
        
    }
}