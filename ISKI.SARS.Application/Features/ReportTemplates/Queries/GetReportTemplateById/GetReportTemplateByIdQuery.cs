using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using MediatR;
using System;

namespace ISKI.SARS.Application.Features.ReportTemplates.Queries.GetReportTemplateById;

public class GetReportTemplateByIdQuery(int id, Guid userId) : IRequest<GetReportTemplateDto>
{
    public int Id { get; set; } = id;
    public Guid UserId { get; set; } = userId;
}

