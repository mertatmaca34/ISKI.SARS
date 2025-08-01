using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Commands.CreateReportTemplateArchiveTag;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Commands.DeleteReportTemplateArchiveTag;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Dtos;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Queries.GetReportTemplateArchiveTagById;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Queries.GetReportTemplateArchiveTags;
using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportTemplateArchiveTagsController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReportTemplateArchiveTagCommand command)
    {
        GetReportTemplateArchiveTagDto result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteReportTemplateArchiveTagCommand { Id = id };
        GetReportTemplateArchiveTagDto result = await mediator.Send(command);
        return Ok(result);
    }

    [Authorize(Roles = "Admin,Operator")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetReportTemplateArchiveTagByIdQuery(id);
        GetReportTemplateArchiveTagDto result = await mediator.Send(query);
        return Ok(result);
    }

    [Authorize(Roles = "Admin,Operator")]
    [HttpPost("list")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery)
    {
        var query = new GetReportTemplateArchiveTagListQuery
        {
            PageRequest = pageRequest,
            DynamicQuery = dynamicQuery
        };
        PaginatedList<GetReportTemplateArchiveTagDto> result = await mediator.Send(query);
        return Ok(result);
    }
}
