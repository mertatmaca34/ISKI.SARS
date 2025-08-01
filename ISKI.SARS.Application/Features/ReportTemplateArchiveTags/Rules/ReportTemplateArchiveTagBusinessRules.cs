using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Constants;
using ISKI.SARS.Domain.Services;
using ISKI.Core.CrossCuttingConcerns.Exceptions;

namespace ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Rules;

public class ReportTemplateArchiveTagBusinessRules(IReportTemplateArchiveTagRepository repository)
{
    private readonly IReportTemplateArchiveTagRepository _repository = repository;

    public async Task MappingMustBeUnique(int templateId, int archiveTagId)
    {
        var exists = await _repository.GetAsync(x => x.ReportTemplateId == templateId && x.ArchiveTagId == archiveTagId);
        if (exists is not null)
            throw new BusinessException(ReportTemplateArchiveTagMessages.DuplicateMapping);
    }

    public async Task MustExist(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            throw new BusinessException(ReportTemplateArchiveTagMessages.NotFound);
    }
}
