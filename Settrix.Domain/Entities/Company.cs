
using Settrix.Domain.Types;

namespace Settrix.Domain.Entities;

/// <summary>
///     The Entity that maintain the data about a company.
///     Also saves if the company is a provider or a requester.
/// </summary>
public class Company : SettrixBaseEntity
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public CompanyFunctionType Function { get; set; } = CompanyFunctionType.Requester;
    public bool IsActive { get; set; } = true;
    public bool InDebt { get; set; } = false;
    public CompanyTierLevelType TierLevel { get; set; }
    public ICollection<User>? Users { get; set; }

    
}
