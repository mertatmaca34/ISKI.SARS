using AutoMapper;
using ISKI.SARS.Application.Features.ArchiveTags.Dtos;
using ISKI.SARS.Application.Features.ArchiveTags.Rules;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.ArchiveTags.Commands.UpdateArchiveTag;

public class UpdateArchiveTagCommandHandler(
    IArchiveTagRepository repository,
    IMapper mapper,
    ArchiveTagBusinessRules rules)
    : IRequestHandler<UpdateArchiveTagCommand, GetArchiveTagDto>
{
    public async Task<GetArchiveTagDto> Handle(UpdateArchiveTagCommand request, CancellationToken cancellationToken)
    {
        await rules.ArchiveTagMustExist(request.Id);
        await rules.TagNodeIdMustBeUnique(request.TagNodeId);

        var entity = await repository.GetByIdAsync(request.Id);
        mapper.Map(request, entity!);
        entity!.UpdatedAt = DateTime.Now;

        var updated = await repository.UpdateAsync(entity!);
        return mapper.Map<GetArchiveTagDto>(updated);
    }
}
