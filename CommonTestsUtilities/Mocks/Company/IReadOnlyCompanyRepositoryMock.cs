using Moq;
using Settrix.Domain.Repositories.Company;

namespace ComunTestsUtilities.Mocks.Company;

public class IReadOnlyCompanyRepositoryMock
{
    private Mock<IReadOnlyCompanyRepository> _repository { get; set; }

    public IReadOnlyCompanyRepositoryMock()
    {
        _repository = new Mock<IReadOnlyCompanyRepository>();
    }

    public IReadOnlyCompanyRepositoryMock IsCnpjAlreadyUsed(string? cnpj = null)
    {
        if (!string.IsNullOrWhiteSpace(cnpj))
        {
            _repository.Setup(repo => repo.GetByCNPJ(cnpj)).ReturnsAsync(true);       
        }
        return this;       
    }
    
    public IReadOnlyCompanyRepository Mocker() => _repository.Object;
}