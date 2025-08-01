using AutoMapper;
using ISKI.SARS.Application.Features.ArchiveTags.Dtos;
using ISKI.SARS.Application.Features.ArchiveTags.Rules;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.ArchiveTags.Commands.CreateArchiveTag;

public class CreateArchiveTagCommandHandler(
    IArchiveTagRepository repository,
    IMapper mapper,
    ArchiveTagBusinessRules rules)
    : IRequestHandler<CreateArchiveTagCommand, GetArchiveTagDto>
{
    public async Task<GetArchiveTagDto> Handle(CreateArchiveTagCommand request, CancellationToken cancellationToken)
    {
        await rules.TagNodeIdMustBeUnique(request.TagNodeId);

        var entity = mapper.Map<ArchiveTag>(request);
        entity.CreatedAt = DateTime.Now;

        var created = await repository.AddAsync(entity);
        return mapper.Map<GetArchiveTagDto>(created);
    }
}
