using CommonTestsUtilities;
using CommonTestsUtilities.Company;
using CommonTestsUtilities.Mocks;
using ComunTestsUtilities.Mocks.Company;
using FluentAssertions;
using Settrix.Application.UseCases.Company.Create;
using Settrix.Exception.BaseExceptions;

namespace UnitTests.UseCases.Company;

public class CreateCompanyUseCaseUnitTest
{
    [Fact]
    public async Task ValidRequest()
    {
        var request = RequestRegisterCompanyBuilder.Build();
        var useCase = CreateUseCase();

        var act = async()=> await useCase.Execute(request);

        await act.Should().NotThrowAsync();
    }

    [Fact]
    public async Task InvalidRequest_CnpjAlreadyUsed()
    {
        var request = RequestRegisterCompanyBuilder.Build();
        var useCase = CreateUseCase(request.Cnpj);
        
        var act = async ()=>await useCase.Execute(request);

        await act.Should().ThrowAsync<ErrorOnRequestValidation>();
    }
    
    [Fact]
    public async Task InvalidRequest_EmptyCnpj()
    {
        var request = RequestRegisterCompanyBuilder.Build();
        var useCase = CreateUseCase();
        request.Cnpj = String.Empty;
        
        var act = async ()=>await useCase.Execute(request);

        await act.Should().ThrowAsync<ErrorOnRequestValidation>();
    }
    
    private CreateCompanyUseCase CreateUseCase(string? cnpj = null)
    {
        var readOnlyRepository = new IReadOnlyCompanyRepositoryMock();
        var writeOnlyRepository = new IWriteOnlyCompanyRepositoryMock();
        
        return new CreateCompanyUseCase(
            mapper:AutoMapperBuilder.Build(),
            loggedUser: LoggedUserProviderMock.Mocker(),
            readRepository: readOnlyRepository.IsCnpjAlreadyUsed(cnpj).Mocker(),
            writeRepository: writeOnlyRepository.Mocker()
        );
    }
}