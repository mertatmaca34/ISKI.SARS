using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Dtos;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Rules;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Commands.DeleteReportTemplateArchiveTag;

public class DeleteReportTemplateArchiveTagCommandHandler(
    IReportTemplateArchiveTagRepository repository,
    IMapper mapper,
    ReportTemplateArchiveTagBusinessRules rules)
    : IRequestHandler<DeleteReportTemplateArchiveTagCommand, GetReportTemplateArchiveTagDto>
{
    public async Task<GetReportTemplateArchiveTagDto> Handle(DeleteReportTemplateArchiveTagCommand request, CancellationToken cancellationToken)
    {
        await rules.MustExist(request.Id);
        var entity = await repository.GetByIdAsync(request.Id);
        var deleted = await repository.DeleteAsync(entity!);
        return mapper.Map<GetReportTemplateArchiveTagDto>(deleted!);
    }
}
