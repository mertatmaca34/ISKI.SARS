using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Commands.CreateReportTemplateArchiveTag;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Dtos;
using ISKI.SARS.Domain.Entities;

namespace ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Profiles;

public class ReportTemplateArchiveTagMappingProfile : Profile
{
    public ReportTemplateArchiveTagMappingProfile()
    {
        CreateMap<CreateReportTemplateArchiveTagCommand, ReportTemplateArchiveTag>();
        CreateMap<ReportTemplateArchiveTag, GetReportTemplateArchiveTagDto>();
    }
}
