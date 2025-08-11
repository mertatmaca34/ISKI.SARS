using ISKI.Core.Domain;
using System;

namespace ISKI.SARS.Domain.Entities;

public class ReportTemplateUser : BaseEntity<int>
{
    public int ReportTemplateId { get; set; }
    public Guid UserId { get; set; }
    public ReportTemplate? ReportTemplate { get; set; }
}

