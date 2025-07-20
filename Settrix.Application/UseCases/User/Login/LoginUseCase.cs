using Settrix.Comunication.DTO_s.Request;
using Settrix.Comunication.DTO_s.Response;
using Settrix.Comunication.Resources.User;
using Settrix.Domain.Repositories;
using Settrix.Domain.Security.Authentication;
using Settrix.Domain.Security.Criptography;
using Settrix.Exception.BaseExceptions;

namespace Settrix.Application.UseCases.User.Login;

public class LoginUseCase : ILoginUseCase
{
    private readonly IReadOnlyUserRepository _repository;
    private readonly ICriptographyHanddle _criptography;
    private readonly ILogginUser _logginUser;
    
    public LoginUseCase( ILogginUser logginUser,
        IReadOnlyUserRepository repository,
        ICriptographyHanddle criptographyHanddle)
    {
        _logginUser = logginUser;
        _repository = repository;
        _criptography = criptographyHanddle;
    }
    
    public async Task<ResponseLoggedUserJson> Execute(RequestLoginCredentialsJson credentials)
    {
        var userLogged = await Authenticate(credentials);
        
        return new ResponseLoggedUserJson()
        {
            Email = userLogged.Email,
            Token = _logginUser.Generate(userLogged),
        };
    }

    private async Task<Domain.Entities.User> Authenticate(RequestLoginCredentialsJson credentials)
    {
        var savedUser = await _repository.GetByEmail(credentials.Email);
        
        if (savedUser == null)
        {
            throw new ErrorUnauthorized(UserResource.EMAIL_NOT_REGISTERED);
        }
        
        var isPasswordValid = _criptography.VerifyPassword(credentials.Password, savedUser.Password);
        
        if (!isPasswordValid)
        {
            throw new ErrorUnauthorized(UserResource.INCORRECT_CREDENTIALS);
        }

        return savedUser;
    }
}