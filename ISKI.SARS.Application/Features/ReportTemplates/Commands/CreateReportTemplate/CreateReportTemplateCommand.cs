using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using MediatR;
using System;
using System.Collections.Generic;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands.CreateReportTemplate;

public class CreateReportTemplateCommand : IRequest<GetReportTemplateDto>
{
    public string Name { get; set; } = string.Empty;
    public Guid CreatedByUserId { get; set; }
    public List<Guid> SharedUserIds { get; set; } = new();
}

