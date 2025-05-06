using AutoMapper;
using ISKI.SARS.Application.Features.Tags.Dtos;
using ISKI.SARS.Application.Features.Tags.Rules;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.Tags.Commands.CreateTag;

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, GetTagDto>
{
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;
    private readonly TagBusinessRules _businessRules;

    public CreateTagCommandHandler(ITagRepository tagRepository, IMapper mapper, TagBusinessRules businessRules)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<GetTagDto> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.TagDisplayNameMustBeUnique(request.DisplayName);

        var tag = _mapper.Map<Tag>(request);
        tag.Id = Guid.NewGuid();
        tag.CreatedAt = DateTime.UtcNow;

        var createdTag = await _tagRepository.AddAsync(tag);
        return _mapper.Map<GetTagDto>(createdTag);
    }
}
