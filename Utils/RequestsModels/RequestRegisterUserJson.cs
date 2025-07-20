using Utils.Types;

namespace Utils.RequestsModels
;
public class RequestRegisterUserJson
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRoleType Role { get; set; } = UserRoleType.Employee;
    
    
    public long CompanyId { get; set; }
    public long CreatedBy { get; set; }

}
