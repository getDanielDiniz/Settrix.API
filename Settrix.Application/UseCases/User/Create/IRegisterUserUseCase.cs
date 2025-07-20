using Settrix.Comunication.DTO_s.Request;
using Settrix.Comunication.DTO_s.Response;

namespace Settrix.Application.UseCases.User.Create;
public interface IRegisterUserUseCase
{
    Task<ResponseLoggedUserJson> Execute(RequestRegisterUserJson newUser);
}
