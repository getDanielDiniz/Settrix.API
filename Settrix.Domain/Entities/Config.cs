namespace Settrix.Domain.Entities;
public class Config : SettrixBaseEntity
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public Company Company { get; set; } = default!;

    public List<Column> Columns { get; set; } = default!;
    public List<WorkFlowStep> WorkFlowSteps { get; set; } = default!;
}
