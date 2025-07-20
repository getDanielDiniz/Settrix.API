using CommonTestsUtilities;
using CommonTestsUtilities.Mocks;
using CommunTestsUtilities;
using ComunTestsUtilities.Builders;
using ComunTestsUtilities.Mocks;
using FluentAssertions;
using Settrix.Application.UseCases.User.Create;
using Settrix.Exception.BaseExceptions;

namespace UnitTests;

public class UserUseCaseUnitTest
{
    [Fact]
    public async Task ValidRequest()
    {
        var useCase = CreateUseCase();
        var request = RequestRegisterUserBuilder.Build();
        
        var response = await useCase.Execute(request);
        
        response.Email.Should().Be(request.Email);
        response.Token.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task ErrorOnValidation()
    {
        var useCase = CreateUseCase();
        var request = RequestRegisterUserBuilder.Build();
        request.Email = String.Empty;
        
        var act = async ()=>await useCase.Execute(request);

        await act.Should().ThrowAsync<ErrorOnUserValidation>();
    }

    [Fact]
    public async Task ErrorEmailAlreadyUsed()
    {
        var request = RequestRegisterUserBuilder.Build();
        var useCase = CreateUseCase(request.Email);
        
        var act = async ()=> await useCase.Execute(request);
        
        await act.Should().ThrowAsync<ErrorEmailAlreadyInUse>();
    }
    
    private RegisterUserUseCase CreateUseCase(string? email = null)
    {
        var mapper = AutoMapperBuilder.Build();
        var logginUser = LogInUserMock.Mocker();
        var criptoHanddler = new CriptographyHanddleMock().Mocker();
        var writeRepository = new WriteOnlyUserRepositoryMock().Mocker();
        var readRepository = new ReadOnlyUserRepositoryMock().isEmailAlreadyUsed(email).Mocker();
        var loggedUser = LoggedUserProviderMock.Mocker();

        return new RegisterUserUseCase(writeRepository, mapper,criptoHanddler, logginUser, readRepository, loggedUser);
    }
}