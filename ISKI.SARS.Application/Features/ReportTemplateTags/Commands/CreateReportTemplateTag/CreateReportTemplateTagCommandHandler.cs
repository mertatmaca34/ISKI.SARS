using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplateTags.Dtos;
using ISKI.SARS.Application.Features.ReportTemplateTags.Rules;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplateTags.Commands.CreateReportTemplateTag;

public class CreateReportTemplateTagCommandHandler(
    IReportTemplateTagRepository repository,
    IMapper mapper,
    ReportTemplateTagBusinessRules rules)
    : IRequestHandler<CreateReportTemplateTagCommand, GetReportTemplateTagDto>
{
    public async Task<GetReportTemplateTagDto> Handle(CreateReportTemplateTagCommand request, CancellationToken cancellationToken)
    {
        await rules.TagNodeIdMustBeUnique(request.TagNodeId, request.ReportTemplateId);

        var entity = mapper.Map<ReportTemplateTag>(request);
        entity.CreatedAt = DateTime.UtcNow;

        var created = await repository.AddAsync(entity);
        return mapper.Map<GetReportTemplateTagDto>(created);
    }
}
