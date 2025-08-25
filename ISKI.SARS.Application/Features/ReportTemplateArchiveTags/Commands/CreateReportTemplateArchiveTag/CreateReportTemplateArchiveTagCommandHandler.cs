using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Dtos;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Rules;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Commands.CreateReportTemplateArchiveTag;

public class CreateReportTemplateArchiveTagCommandHandler(
    IReportTemplateArchiveTagRepository repository,
    IMapper mapper,
    ReportTemplateArchiveTagBusinessRules rules)
    : IRequestHandler<CreateReportTemplateArchiveTagCommand, GetReportTemplateArchiveTagDto>
{
    public async Task<GetReportTemplateArchiveTagDto> Handle(CreateReportTemplateArchiveTagCommand request, CancellationToken cancellationToken)
    {
        await rules.MappingMustBeUnique(request.ReportTemplateId, request.ArchiveTagId);

        var entity = mapper.Map<ReportTemplateArchiveTag>(request);
        entity.CreatedAt = DateTime.Now;

        var created = await repository.AddAsync(entity);
        return mapper.Map<GetReportTemplateArchiveTagDto>(created);
    }
}
