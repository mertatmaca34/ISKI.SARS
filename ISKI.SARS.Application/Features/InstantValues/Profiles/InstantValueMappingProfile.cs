using AutoMapper;
using ISKI.SARS.Application.Features.InstantValues.Commands.CreateInstantValue;
using ISKI.SARS.Application.Features.InstantValues.Dtos;
using ISKI.SARS.Domain.Entities;

namespace ISKI.SARS.Application.Features.InstantValues.Profiles;

public class InstantValueMappingProfile : Profile
{
    public InstantValueMappingProfile()
    {
        CreateMap<CreateInstantValueCommand, InstantValue>();

        CreateMap<InstantValue, GetInstantValueDto>()
            .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Id));
    }
}
