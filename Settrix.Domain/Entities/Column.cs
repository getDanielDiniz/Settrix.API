namespace Settrix.Domain.Entities;
public class Column : SettrixBaseEntity
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool CanBeEmpty { get; set; }
    public bool IsActive { get; set; }
    public int TablePosition { get; set; }
    public string InputType { get; set; } = string.Empty;
    public string Visibility { get; set; } = string.Empty;
    public long ConfigId { get; set; }
    public Config? Config { get; set; }
}
