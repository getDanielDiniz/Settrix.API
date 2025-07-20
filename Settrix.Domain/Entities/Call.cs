namespace Settrix.Domain.Entities;

/// <summary>
/// Call Entity
/// </summary>
public class Call : SettrixBaseEntity
{
    public long Id { get; set; }
    public required string Data { get; set; }
    public DateOnly? StartedAt { get; set; }
    public DateOnly? DeadLine { get; set; }
    
    public long ConfigId { get; set; }
    public required Config? Config { get; set; }
    public long ProviderId { get; set; }
    public Company? Provider { get; set; }
    public long RequesterId { get; set; }
    public Company? Requester { get; set; }
    public long ResponsibleId { get; set; }
    public User? Responsible { get; set; }

}
