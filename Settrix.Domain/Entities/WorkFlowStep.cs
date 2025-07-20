
using Settrix.Domain.Types;

namespace Settrix.Domain.Entities;
public class WorkFlowStep: SettrixBaseEntity
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsClientAbbleToEdit { get; set; }
    public WorkFlowStepStatusType Status { get; set; } = 0;
    public long CompanyId { get; set; }
    public Company? Company { get; set; }
}
