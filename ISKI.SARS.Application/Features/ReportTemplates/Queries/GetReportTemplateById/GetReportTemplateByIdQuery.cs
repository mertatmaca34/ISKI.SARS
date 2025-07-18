using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplates.Queries.GetReportTemplateById;

public class GetReportTemplateByIdQuery(int id) : IRequest<GetReportTemplateDto>
{
    public int Id { get; set; } = id;
}