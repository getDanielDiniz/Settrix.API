using Settrix.Domain.Types;

namespace Settrix.Comunication.DTO_s.Request;
public class RequestRegisterUserJson
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRoleType Role { get; set; } = UserRoleType.Employee;

}
