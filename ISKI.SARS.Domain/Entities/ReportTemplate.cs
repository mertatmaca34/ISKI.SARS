using ISKI.Core.Domain;
using System;
using System.Collections.Generic;

namespace ISKI.SARS.Domain.Entities;

public class ReportTemplate : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public Guid CreatedByUserId { get; set; }
    public ICollection<ReportTemplateUser> ReportTemplateUsers { get; set; } = new List<ReportTemplateUser>();
    public ICollection<ReportTemplateArchiveTag> ReportTemplateArchiveTags { get; set; } = new List<ReportTemplateArchiveTag>();
}

