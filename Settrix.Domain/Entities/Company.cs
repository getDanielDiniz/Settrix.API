
using Settrix.Domain.Types;

namespace Settrix.Domain.Entities;

/// <summary>
///     The Entity that maintain the data about a company.
///     Also saves if the company is a provider or a requester.
/// </summary>
public class Company
{
    public string Name { get; set; } = string.Empty;
    public long Id { get; set; }
    public CompanyFunctionType Function { get; set; } = CompanyFunctionType.Requester;
    public bool IsActive { get; set; }
    public bool InDebt { get; set; }
    public CompanyTierLevelType TierLevel { get; set; }
    
    public ICollection<Config>? Configs { get; set; }
    public ICollection<User>? Users { get; set; }

    
}
