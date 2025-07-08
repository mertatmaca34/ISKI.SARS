using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.WebUI.ViewModels.ReportTemplates;

namespace ISKI.SARS.WebUI.Mapping;

public class WebUiMappingProfile : Profile
{
    public WebUiMappingProfile()
    {
        CreateMap<GetReportTemplateDto, ReportTemplateVm>().ReverseMap();
    }
}
