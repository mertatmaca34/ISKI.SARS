namespace ISKI.SARS.Domain.Common;

public abstract class BaseEntity<T>
{
    public required T Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
