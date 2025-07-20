namespace Settrix.Domain.Entities;
public abstract class SettrixBaseEntity
{
    public required DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public long CreatedBy { get; set; }
    public User? CreatedByUser { get; set; }
    public long? UpdatedBy { get; set; }
    public User? UpdatedByUser { get; set; }
}