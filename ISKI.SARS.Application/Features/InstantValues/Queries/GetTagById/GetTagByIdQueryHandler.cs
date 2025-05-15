using AutoMapper;
using ISKI.SARS.Application.Features.Tags.Dtos;
using ISKI.SARS.Application.Features.Tags.Rules;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.Tags.Queries.GetTagById;

public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagDto>
{
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;
    private readonly TagBusinessRules _businessRules;

    public GetTagByIdQueryHandler(ITagRepository tagRepository, IMapper mapper, TagBusinessRules businessRules)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<GetTagDto> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {
        var tag = await _tagRepository.GetByIdAsync(request.Id);
        await _businessRules.TagMustExist(request.Id);

        return _mapper.Map<GetTagDto>(tag);
    }
}
