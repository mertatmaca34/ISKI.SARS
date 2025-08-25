using System;
using System.Collections.Generic;

namespace ISKI.SARS.Application.Features.ReportTemplates.Dtos;

public class GetReportTemplateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid CreatedByUserId { get; set; }
    public bool IsShared { get; set; }
    public List<Guid> SharedUserIds { get; set; } = new();
}

