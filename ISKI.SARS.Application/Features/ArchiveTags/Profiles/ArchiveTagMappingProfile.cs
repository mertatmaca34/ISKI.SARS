using AutoMapper;
using ISKI.SARS.Application.Features.ArchiveTags.Commands.CreateArchiveTag;
using ISKI.SARS.Application.Features.ArchiveTags.Commands.UpdateArchiveTag;
using ISKI.SARS.Application.Features.ArchiveTags.Dtos;
using ISKI.SARS.Domain.Entities;

namespace ISKI.SARS.Application.Features.ArchiveTags.Profiles;

public class ArchiveTagMappingProfile : Profile
{
    public ArchiveTagMappingProfile()
    {
        CreateMap<CreateArchiveTagCommand, ArchiveTag>();
        CreateMap<UpdateArchiveTagCommand, ArchiveTag>();
        CreateMap<ArchiveTag, GetArchiveTagDto>();
    }
}
