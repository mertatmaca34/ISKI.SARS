using AutoMapper;
using ISKI.SARS.Application.Features.ArchiveTags.Dtos;
using ISKI.SARS.Application.Features.ArchiveTags.Rules;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.ArchiveTags.Commands.DeleteArchiveTag;

public class DeleteArchiveTagCommandHandler(
    IArchiveTagRepository repository,
    IMapper mapper,
    ArchiveTagBusinessRules rules)
    : IRequestHandler<DeleteArchiveTagCommand, GetArchiveTagDto>
{
    public async Task<GetArchiveTagDto> Handle(DeleteArchiveTagCommand request, CancellationToken cancellationToken)
    {
        await rules.ArchiveTagMustExist(request.Id);
        var entity = await repository.GetByIdAsync(request.Id);
        var deleted = await repository.DeleteAsync(entity!);
        return mapper.Map<GetArchiveTagDto>(deleted!);
    }
}
