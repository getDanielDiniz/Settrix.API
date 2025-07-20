using Moq;
using Settrix.Domain.Repositories;

namespace ComunTestsUtilities.Mocks;

public class WriteOnlyUserRepositoryMock
{
    private Mock<IWriteOnlyUserRepository> _repository { get; set; }

    public WriteOnlyUserRepositoryMock()
    {
        _repository = new Mock<IWriteOnlyUserRepository>();
    }
    
    public IWriteOnlyUserRepository Mocker() => _repository.Object;
}