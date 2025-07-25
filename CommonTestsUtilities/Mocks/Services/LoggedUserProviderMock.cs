using ComunTestsUtilities.Builders;
using Moq;
using Settrix.Domain.Services.LoggedUser;

namespace CommonTestsUtilities.Mocks;

public class LoggedUserProviderMock
{
    public static ILoggedUserProvider Mocker()
    {
        var user = UserEntityBuilder.Build();
        var mock = new Mock<ILoggedUserProvider>();
        mock.Setup(m => m.Get()).ReturnsAsync(user);
        
        return mock.Object;       
    }
}