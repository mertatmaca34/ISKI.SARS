using ISKI.Core.Domain;
using ISKI.SARS.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ISKI.SARS.Domain.Entities;

public class ReportTemplate : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string OpcEndpoint { get; set; } = string.Empty;
    public int PullInterval { get; set; }
    public bool IsActive { get; set; } = true;

    public Guid CreatedByUserId { get; set; }

    public ICollection<ReportTemplateUser> ReportTemplateUsers { get; set; } = new List<ReportTemplateUser>();
}
