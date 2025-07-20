using Moq;
using Settrix.Domain.Security.Criptography;

namespace ComunTestsUtilities.Mocks;

public class CriptographyHanddleMock
{
    private Mock<ICriptographyHanddle> _mock { get; set; }

    public CriptographyHanddleMock()
    {
        _mock = new Mock<ICriptographyHanddle>();
        
        _mock.Setup(serv => serv.HashPassword(It.IsAny<string>())).Returns("$hashedPassword");
    }

    public CriptographyHanddleMock isPasswordValid(string? password = null)
    {
        if (!string.IsNullOrWhiteSpace(password))
        {
            _mock.Setup(serv => 
                serv.VerifyPassword(password, It.IsAny<string>()))
                .Returns(true);
        }
        
        return this;       
    }
    
    public ICriptographyHanddle Mocker() =>  _mock.Object;       
    
}