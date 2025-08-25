using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.Application.Features.ReportTemplates.Rules;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;
using System;
using System.Linq;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands.UpdateReportTemplate;

public class UpdateReportTemplateCommandHandler(
    IReportTemplateRepository repository,
    IReportTemplateUserRepository shareRepository,
    IMapper mapper,
    ReportTemplateBusinessRules rules)
    : IRequestHandler<UpdateReportTemplateCommand, GetReportTemplateDto>
{
    public async Task<GetReportTemplateDto> Handle(UpdateReportTemplateCommand request, CancellationToken cancellationToken)
    {
        await rules.ReportTemplateMustExist(request.Id);

        var entity = await repository.GetByIdAsync(request.Id);
        mapper.Map(request, entity!);

        var updated = await repository.UpdateAsync(entity!);

        var existingShares = await shareRepository.GetAllAsync(
            x => x.ReportTemplateId == request.Id && x.DeletedAt == null);

        var existingUserIds = existingShares.Select(x => x.UserId).ToList();
        var newUserIds = request.SharedUserIds.Distinct().ToList();

        foreach (var share in existingShares.Where(x => !newUserIds.Contains(x.UserId)))
            await shareRepository.DeleteAsync(share);

        foreach (var userId in newUserIds.Where(id => !existingUserIds.Contains(id)))
        {
            var share = new ReportTemplateUser
            {
                ReportTemplateId = request.Id,
                UserId = userId,
                CreatedAt = DateTime.Now
            };

            await shareRepository.AddAsync(share);
        }

        return mapper.Map<GetReportTemplateDto>(updated);
    }
}
