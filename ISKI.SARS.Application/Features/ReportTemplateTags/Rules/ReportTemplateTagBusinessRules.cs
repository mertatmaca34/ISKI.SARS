using ISKI.SARS.Application.Features.ReportTemplateTags.Constants;
using ISKI.SARS.Domain.Services;
using ISKI.Core.CrossCuttingConcerns.Exceptions;

namespace ISKI.SARS.Application.Features.ReportTemplateTags.Rules;

public class ReportTemplateTagBusinessRules(IReportTemplateTagRepository repository)
{
    private readonly IReportTemplateTagRepository _repository = repository;

    public async Task TagNodeIdMustBeUnique(string tagNodeId, int reportTemplateId)
    {
        var exists = await _repository.GetAsync(x => x.ReportTemplateId == reportTemplateId && x.TagNodeId == tagNodeId);
        if (exists is not null)
            throw new BusinessException(ReportTemplateTagMessages.DuplicateTagNodeId);
    }
}
