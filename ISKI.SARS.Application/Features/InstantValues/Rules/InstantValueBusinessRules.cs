using ISKI.SARS.Application.Features.InstantValues.Constants;
using ISKI.SARS.Domain.Services;
using ISKI.Core.CrossCuttingConcerns.Exceptions;

namespace ISKI.SARS.Application.Features.InstantValues.Rules;

public class InstantValueBusinessRules(IInstantValueRepository instantValueRepository)
{
    private readonly IInstantValueRepository _instantValueRepository = instantValueRepository;

    public async Task TimestampMustBeUnique(int archiveTagId, DateTime timestamp)
    {
        var existing = await _instantValueRepository.GetAsync(x =>
            x.ArchiveTagId == archiveTagId && x.Id == timestamp);

        if (existing is not null)
            throw new BusinessException(InstantValueMessages.TimestampMustBeUnique);
    }

    public void ValueCannotBeEmpty(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new BusinessException(InstantValueMessages.ValueCannotBeEmpty);
    }

    public void EnsureValidTagId(int tagId)
    {
        if (tagId <= 0)
            throw new BusinessException(InstantValueMessages.InvalidTagId);
    }
    public async Task MustExist(DateTime timestamp)
    {
        var entity = await _instantValueRepository.GetByIdAsync(timestamp);

        if (entity is null)
            throw new BusinessException(InstantValueMessages.InstantValueNotFound);
    }
}
