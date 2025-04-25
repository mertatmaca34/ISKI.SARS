using AutoMapper;
using ISKI.SARS.Application.Features.Tags.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISKI.SARS.Domain.Entities;
namespace ISKI.SARS.Application.Features.Tags.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Tag, TagDto>().ReverseMap();
        CreateMap<Tag, CreateTagDto>().ReverseMap();
    }
}