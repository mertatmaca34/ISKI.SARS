using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.SARS.Domain.Services;

namespace ISKI.SARS.Application.Features.Tags.Rules;

public class TagBusinessRules
{
    private readonly ITagRepository _tagRepository;

    public TagBusinessRules(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task TagDisplayNameMustBeUnique(string displayName)
    {
        var existingTag = await _tagRepository.GetAsync(x => x.DisplayName == displayName);
        if (existingTag != null)
            throw new BusinessException("Aynı isimde bir Tag zaten mevcut.");
    }

    public async Task TagMustExist(Guid id)
    {
        var existingTag = await _tagRepository.GetByIdAsync(id);
        if (existingTag == null)
            throw new BusinessException("Böyle bir Tag bulunamadı.");
    }
}
