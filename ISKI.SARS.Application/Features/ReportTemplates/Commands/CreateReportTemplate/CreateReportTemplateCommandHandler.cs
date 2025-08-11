using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.Application.Features.ReportTemplates.Rules;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;
using System;
using System.Linq;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands.CreateReportTemplate;

public class CreateReportTemplateCommandHandler(
    IReportTemplateRepository repository,
    IReportTemplateUserRepository shareRepository,
    IReportTemplateTagRepository tagRepository,
    IMapper mapper,
    ReportTemplateBusinessRules rules)
    : IRequestHandler<CreateReportTemplateCommand, GetReportTemplateDto>
{
    public async Task<GetReportTemplateDto> Handle(CreateReportTemplateCommand request, CancellationToken cancellationToken)
    {
        await rules.NameMustBeUnique(request.Name);

        var entity = mapper.Map<ReportTemplate>(request);
        entity.CreatedAt = DateTime.Now;

        var created = await repository.AddAsync(entity);

        foreach (var tag in request.Tags)
        {
            var tagEntity = new ReportTemplateTag
            {
                ReportTemplateId = created.Id,
                TagName = tag.TagName,
                TagNodeId = tag.TagNodeId,
                Description = tag.Description,
                Type = tag.Type,
                CreatedAt = DateTime.Now
            };

            await tagRepository.AddAsync(tagEntity);
        }

        foreach (var userId in request.SharedUserIds.Distinct())
        {
            var share = new ReportTemplateUser
            {
                ReportTemplateId = created.Id,
                UserId = userId,
                CreatedAt = DateTime.Now
            };

            await shareRepository.AddAsync(share);
        }

        return mapper.Map<GetReportTemplateDto>(created);
    }
}