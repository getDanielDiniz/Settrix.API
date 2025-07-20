using System.ComponentModel.DataAnnotations.Schema;
using Settrix.Domain.Types;

namespace Settrix.Domain.Entities;

/// <summary>
/// User Entity 
/// </summary>
public class User : SettrixBaseEntity
{
    public long Id { get; set; }
    public required Guid SecurityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; }= string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRoleType Role {  get; set; } = UserRoleType.Employee;
    public bool IsActive { get; set; } = true;
    
    [ForeignKey("Company")]
    public long CompanyId { get; set; }
    public Company Company { get; set; }
}
