using ISKI.SARS.Application.Features.ArchiveTags.Constants;
using ISKI.SARS.Domain.Services;
using ISKI.Core.CrossCuttingConcerns.Exceptions;

namespace ISKI.SARS.Application.Features.ArchiveTags.Rules;

public class ArchiveTagBusinessRules(IArchiveTagRepository repository)
{
    private readonly IArchiveTagRepository _repository = repository;

    public async Task TagNodeIdMustBeUnique(string tagNodeId)
    {
        var exists = await _repository.GetAsync(x => x.TagNodeId == tagNodeId);
        if (exists is not null)
            throw new BusinessException(ArchiveTagMessages.DuplicateTagNodeId);
    }

    public async Task ArchiveTagMustExist(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            throw new BusinessException(ArchiveTagMessages.NotFound);
    }
}
