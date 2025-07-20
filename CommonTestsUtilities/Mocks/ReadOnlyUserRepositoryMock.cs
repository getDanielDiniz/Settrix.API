using ComunTestsUtilities.Builders;
using Moq;
using Settrix.Domain.Repositories;

namespace ComunTestsUtilities.Mocks;

public class ReadOnlyUserRepositoryMock
{
    private Mock<IReadOnlyUserRepository> _repository { get; set; }
    
    public ReadOnlyUserRepositoryMock()
    {
        _repository = new Mock<IReadOnlyUserRepository>();
    }
    
    public ReadOnlyUserRepositoryMock isEmailAlreadyUsed(string? email = null)
    {
        if (!string.IsNullOrWhiteSpace(email))
        {
            _repository.Setup(repo => repo.EmailAlreadyExists(email)).ReturnsAsync(true);
        }
        
        return this;
    }

    public ReadOnlyUserRepositoryMock getUserByEmail(string? email = null)
    {
        if (!string.IsNullOrWhiteSpace(email))
        {
            _repository.Setup(repo => repo.GetByEmail(email)).ReturnsAsync(UserEntityBuilder.Build());
        }
        
        return this;
    }
    
    public IReadOnlyUserRepository Mocker() => _repository.Object;
}