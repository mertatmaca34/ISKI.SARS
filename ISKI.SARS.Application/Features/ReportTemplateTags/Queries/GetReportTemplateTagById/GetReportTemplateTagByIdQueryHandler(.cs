using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplateTags.Constants;
using ISKI.SARS.Application.Features.ReportTemplateTags.Dtos;
using ISKI.SARS.Domain.Services;
using MediatR;
using ISKI.Core.CrossCuttingConcerns.Exceptions;

namespace ISKI.SARS.Application.Features.ReportTemplateTags.Queries.GetReportTemplateTagById;

public class GetReportTemplateTagByIdQueryHandler(
    IReportTemplateTagRepository repository,
    IMapper mapper)
    : IRequestHandler<GetReportTemplateTagByIdQuery, GetReportTemplateTagDto>
{
    public async Task<GetReportTemplateTagDto> Handle(GetReportTemplateTagByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id);

        if (entity is null)
            throw new BusinessException(ReportTemplateTagMessages.NotFound);

        return mapper.Map<GetReportTemplateTagDto>(entity);
    }
}