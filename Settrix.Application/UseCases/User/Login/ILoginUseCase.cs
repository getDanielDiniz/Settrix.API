using Settrix.Comunication.DTO_s.Request;
using Settrix.Comunication.DTO_s.Response;

namespace Settrix.Application.UseCases.User.Login;

public interface ILoginUseCase
{
    Task<ResponseLoggedUserJson> Execute(RequestLoginCredentialsJson credentials);
}