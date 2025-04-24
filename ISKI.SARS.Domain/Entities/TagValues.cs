using ISKI.SARS.Core.Domain;

namespace ISKI.SARS.Domain.Entities;

public class TagValues : BaseEntity<Guid>
{
    public Guid TagId { get; set; }
    public string Value { get; set; } = string.Empty;
    public DateTime RecordDate { get; set; }
}
