using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplateTags.Dtos;
using ISKI.SARS.Application.Features.ReportTemplateTags.Rules;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplateTags.Commands.DeleteReportTemplateTag;

public class DeleteReportTemplateTagCommandHandler(
    IReportTemplateTagRepository repository,
    IMapper mapper,
    ReportTemplateTagBusinessRules rules)
    : IRequestHandler<DeleteReportTemplateTagCommand, GetReportTemplateTagDto>
{
    public async Task<GetReportTemplateTagDto> Handle(DeleteReportTemplateTagCommand request, CancellationToken cancellationToken)
    {
        await rules.ReportTemplateTagMustExist(request.Id);
        var entity = await repository.GetByIdAsync(request.Id);
        var deleted = await repository.DeleteAsync(entity!);
        return mapper.Map<GetReportTemplateTagDto>(deleted!);
    }
}
