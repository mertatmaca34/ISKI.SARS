using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ISKI.SARS.Application.Features.ReportTemplates.Commands.CreateReportTemplate;
using ISKI.SARS.Application.Features.ReportTemplates.Queries.GetReportTemplateById;
using ISKI.SARS.Application.Features.ReportTemplates.Queries.GetReportTemplates;
using ISKI.SARS.Application.Features.ReportTemplates.Commands.ChangeStatus;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportTemplatesController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReportTemplateCommand command)
    {
        GetReportTemplateDto result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}/status")]
    public async Task<IActionResult> ChangeStatus(int id, [FromBody] bool isActive)
    {
        var command = new ChangeReportTemplateStatusCommand { Id = id, IsActive = isActive };
        GetReportTemplateDto result = await mediator.Send(command);
        return Ok(result);
    }

    [Authorize(Roles = "Admin,Operator")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetReportTemplateByIdQuery(id);
        GetReportTemplateDto result = await mediator.Send(query);
        return Ok(result);
    }

    [Authorize(Roles = "Admin,Operator")]
    [HttpPost("list")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery)
    {
        var query = new GetReportTemplateListQuery
        {
            PageRequest = pageRequest,
            DynamicQuery = dynamicQuery
        };

        PaginatedList<GetReportTemplateDto> result = await mediator.Send(query);
        return Ok(result);
    }
}