using AutoMapper;
using ISKI.SARS.Application.Features.ArchiveTags.Constants;
using ISKI.SARS.Application.Features.ArchiveTags.Dtos;
using ISKI.SARS.Domain.Services;
using MediatR;
using ISKI.Core.CrossCuttingConcerns.Exceptions;

namespace ISKI.SARS.Application.Features.ArchiveTags.Queries.GetArchiveTagById;

public class GetArchiveTagByIdQueryHandler(
    IArchiveTagRepository repository,
    IMapper mapper)
    : IRequestHandler<GetArchiveTagByIdQuery, GetArchiveTagDto>
{
    public async Task<GetArchiveTagDto> Handle(GetArchiveTagByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id);
        if (entity is null)
            throw new BusinessException(ArchiveTagMessages.NotFound);

        return mapper.Map<GetArchiveTagDto>(entity);
    }
}
