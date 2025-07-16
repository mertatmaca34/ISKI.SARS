using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplates.Commands;
using ISKI.SARS.Application.Features.ReportTemplates.Commands.ChangeStatus;
using ISKI.SARS.Application.Features.ReportTemplates.Commands.CreateReportTemplate;
using ISKI.SARS.Application.Features.ReportTemplates.Commands.UpdateReportTemplate;
using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.Domain.Entities;

namespace ISKI.SARS.Application.Features.ReportTemplates.Profiles;

public class ReportTemplateMappingProfile : Profile
{
    public ReportTemplateMappingProfile()
    {
        CreateMap<CreateReportTemplateCommand, ReportTemplate>();
        CreateMap<ChangeReportTemplateStatusCommand, ReportTemplate>();
        CreateMap<UpdateReportTemplateCommand, ReportTemplate>();
        CreateMap<ReportTemplate, GetReportTemplateDto>();
    }
}