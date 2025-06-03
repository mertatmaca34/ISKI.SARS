using ISKI.SARS.Application.Features.ReportTemplates.Constants;
using ISKI.SARS.Domain.Services;
using ISKI.Core.CrossCuttingConcerns.Exceptions;

namespace ISKI.SARS.Application.Features.ReportTemplates.Rules;

public class ReportTemplateBusinessRules(IReportTemplateRepository repository)
{
    private readonly IReportTemplateRepository _repository = repository;

    public async Task NameMustBeUnique(string name)
    {
        var exists = await _repository.GetAsync(x => x.Name == name);
        if (exists is not null)
            throw new BusinessException(ReportTemplateMessages.NameAlreadyExists);
    }
}