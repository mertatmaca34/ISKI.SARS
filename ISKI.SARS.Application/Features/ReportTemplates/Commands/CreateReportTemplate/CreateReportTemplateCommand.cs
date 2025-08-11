using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.Application.Features.ReportTemplateTags.Dtos;
using MediatR;
using System;
using System.Collections.Generic;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands.CreateReportTemplate;

public class CreateReportTemplateCommand : IRequest<GetReportTemplateDto>
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public Guid CreatedByUserId { get; set; }
    public List<CreateReportTemplateTagDto> Tags { get; set; } = new();
    public List<Guid> SharedUserIds { get; set; } = new();
}