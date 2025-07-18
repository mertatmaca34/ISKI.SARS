using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplateTags.Commands;
using ISKI.SARS.Application.Features.ReportTemplateTags.Commands.UpdateReportTemplateTag;
using ISKI.SARS.Application.Features.ReportTemplateTags.Dtos;
using ISKI.SARS.Domain.Entities;

namespace ISKI.SARS.Application.Features.ReportTemplateTags.Profiles;

public class ReportTemplateTagMappingProfile : Profile
{
    public ReportTemplateTagMappingProfile()
    {
        CreateMap<CreateReportTemplateTagCommand, ReportTemplateTag>();
        CreateMap<UpdateReportTemplateTagCommand, ReportTemplateTag>();
        CreateMap<ReportTemplateTag, GetReportTemplateTagDto>();
    }
}