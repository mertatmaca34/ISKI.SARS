using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplates.Commands.CreateReportTemplate;
using ISKI.SARS.Application.Features.ReportTemplates.Commands.UpdateReportTemplate;
using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.Domain.Entities;
using System.Linq;

namespace ISKI.SARS.Application.Features.ReportTemplates.Profiles;

public class ReportTemplateMappingProfile : Profile
{
    public ReportTemplateMappingProfile()
    {
        CreateMap<CreateReportTemplateCommand, ReportTemplate>();
        CreateMap<UpdateReportTemplateCommand, ReportTemplate>();
        CreateMap<ReportTemplate, GetReportTemplateDto>()
            .ForMember(dest => dest.IsShared, opt => opt.Ignore())
            .ForMember(dest => dest.SharedUserIds,
                opt => opt.MapFrom(src => src.ReportTemplateUsers
                    .Where(u => u.DeletedAt == null)
                    .Select(u => u.UserId)));
    }
}

