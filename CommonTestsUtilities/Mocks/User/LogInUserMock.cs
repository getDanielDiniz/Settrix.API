using Moq;
using Settrix.Domain.Entities;
using Settrix.Domain.Security.Authentication;

namespace ComunTestsUtilities.Mocks;

public abstract class LogInUserMock
{

    public static ILogginUser Mocker()
    {
        var mock = new Mock<ILogginUser>();

        mock.Setup(logginUser => logginUser.Generate(It.IsAny<User>())).Returns("$token");
        
        return mock.Object;
    }
}