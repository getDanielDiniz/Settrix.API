using ComunTestsUtilities.Builders;
using ComunTestsUtilities.Mocks;
using FluentAssertions;
using Settrix.Application.UseCases.User.Login;
using Settrix.Comunication.Resources.User;
using Settrix.Exception.BaseExceptions;

namespace UnitTests;

public class LoginUseCaseUnitTest
{
    [Fact]
    public async Task LoginSuccess()
    {
        var request = RequestCredentialLoginBuilder.Build();
        var useCase = CreateUseCase(request.Email, request.Password);

        var response = await useCase.Execute(request);
    
        response.Email.Should().NotBeNullOrWhiteSpace();
        response.Token.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task UserNotFound()
    {
        var request = RequestCredentialLoginBuilder.Build();
        var useCase = CreateUseCase();
        
        var act = async ()=>await useCase.Execute(request);

        await act.Should().ThrowAsync<ErrorUnauthorized>(UserResource.EMAIL_NOT_REGISTERED);
    }

    [Fact]
    public async Task InvalidPassword()
    {
        var request = RequestCredentialLoginBuilder.Build();
        var useCase = CreateUseCase(request.Email);
        
        var act = async ()=>await useCase.Execute(request);
        
        await act.Should().ThrowAsync<ErrorUnauthorized>(UserResource.INVALID_PASSWORD);
    }

    private LoginUseCase CreateUseCase(string? email = null, string? password = null)
    {
        var readRepository = new ReadOnlyUserRepositoryMock().getUserByEmail(email).Mocker();
        var logginUser = LogInUserMock.Mocker();
        var criptographyHanddle = new CriptographyHanddleMock().isPasswordValid(password).Mocker();
        return new LoginUseCase(
            repository:readRepository,
            logginUser:logginUser,
            criptographyHanddle:criptographyHanddle
        );
    }
}