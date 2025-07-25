using System.Linq.Expressions;

namespace Settrix.Application.Types.Roles;

public static class UserRoleExtensionMethods
{
    public static string ToString(this UserRoleType userRole)
    {
        return userRole switch
        {
            UserRoleType.Employee => "Employee",
            UserRoleType.WriterEmployee => "Writer Employee",
            UserRoleType.Lead => "Lead",
            UserRoleType.Supervisor => "Supervisor",
            UserRoleType.Manager => "Manager",
            UserRoleType.CompanyOwner => "Company Owner",
            UserRoleType.SettrixDeveloper => "Settrix Developer",
            _ => "Invalid"
        };
    }
}