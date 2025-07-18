using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplateTags.Dtos;
using ISKI.SARS.Application.Features.ReportTemplateTags.Rules;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplateTags.Commands.UpdateReportTemplateTag;

public class UpdateReportTemplateTagCommandHandler(
    IReportTemplateTagRepository repository,
    IMapper mapper,
    ReportTemplateTagBusinessRules rules)
    : IRequestHandler<UpdateReportTemplateTagCommand, GetReportTemplateTagDto>
{
    public async Task<GetReportTemplateTagDto> Handle(UpdateReportTemplateTagCommand request, CancellationToken cancellationToken)
    {
        await rules.ReportTemplateTagMustExist(request.Id);
        await rules.TagNodeIdMustBeUnique(request.TagNodeId, request.ReportTemplateId);

        var entity = await repository.GetByIdAsync(request.Id);
        mapper.Map(request, entity!);

        var updated = await repository.UpdateAsync(entity!);
        return mapper.Map<GetReportTemplateTagDto>(updated);
    }
}
