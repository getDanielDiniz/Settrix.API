using Moq;
using Settrix.Domain.Repositories.Company;

namespace ComunTestsUtilities.Mocks.Company;

public class IWriteOnlyCompanyRepositoryMock
{
    private Mock<IWriteOnlyCompanyRepository> _repository { get; set; }

    public IWriteOnlyCompanyRepositoryMock()
    {
        _repository = new Mock<IWriteOnlyCompanyRepository>();       
    }
    
    public IWriteOnlyCompanyRepository Mocker() => _repository.Object;
}