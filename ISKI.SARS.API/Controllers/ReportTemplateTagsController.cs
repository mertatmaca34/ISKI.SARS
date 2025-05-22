using ISKI.SARS.Application.Features.ReportTemplateTags.Commands;
using ISKI.SARS.Application.Features.ReportTemplateTags.Dtos;
using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ISKI.SARS.Application.Features.ReportTemplateTags.Queries.GetReportTemplateTagById;
using ISKI.SARS.Application.Features.ReportTemplateTags.Queries.GetReportTemplateTags;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportTemplateTagsController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReportTemplateTagCommand command)
    {
        GetReportTemplateTagDto result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [Authorize(Roles = "Admin,Operator")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetReportTemplateTagByIdQuery(id);
        GetReportTemplateTagDto result = await mediator.Send(query);
        return Ok(result);
    }

    [Authorize(Roles = "Admin,Operator")]
    [HttpPost("list")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery)
    {
        var query = new GetReportTemplateTagListQuery
        {
            PageRequest = pageRequest,
            DynamicQuery = dynamicQuery
        };

        PaginatedList<GetReportTemplateTagDto> result = await mediator.Send(query);
        return Ok(result);
    }
}
