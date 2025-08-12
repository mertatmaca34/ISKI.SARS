using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ISKI.SARS.Application.Features.ReportTemplates.Commands.CreateReportTemplate;
using ISKI.SARS.Application.Features.ReportTemplates.Commands.UpdateReportTemplate;
using ISKI.SARS.Application.Features.ReportTemplates.Commands.DeleteReportTemplate;
using ISKI.SARS.Application.Features.ReportTemplates.Queries.GetReportTemplateById;
using ISKI.SARS.Application.Features.ReportTemplates.Queries.GetReportTemplates;
using ISKI.SARS.Application.Features.ReportTemplates.Commands.ChangeStatus;
using System;
using ISKI.Core.Security.Constants;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportTemplatesController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = GeneralOperationClaims.Admin)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReportTemplateCommand command)
    {
        GetReportTemplateDto result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [Authorize(Roles = GeneralOperationClaims.Admin)]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateReportTemplateCommand command)
    {
        GetReportTemplateDto result = await mediator.Send(command);
        return Ok(result);
    }

    [Authorize(Roles = GeneralOperationClaims.Admin)]
    [HttpPut("{id}/status")]
    public async Task<IActionResult> ChangeStatus(int id, [FromBody] bool isActive)
    {
        var command = new ChangeReportTemplateStatusCommand { Id = id, IsActive = isActive };
        GetReportTemplateDto result = await mediator.Send(command);
        return Ok(result);
    }

    [Authorize(Roles = GeneralOperationClaims.Admin)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteReportTemplateCommand { Id = id };
        GetReportTemplateDto result = await mediator.Send(command);
        return Ok(result);
    }

    [Authorize(Roles = GeneralOperationClaims.Admin + "," + GeneralOperationClaims.Operator)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, [FromQuery] Guid userId)
    {
        var query = new GetReportTemplateByIdQuery(id, userId);
        GetReportTemplateDto result = await mediator.Send(query);
        return Ok(result);
    }

    [Authorize(Roles = GeneralOperationClaims.Admin + "," + GeneralOperationClaims.Operator)]
    [HttpPost("list")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromQuery] Guid userId, [FromBody] DynamicQuery? dynamicQuery)
    {
        var query = new GetReportTemplateListQuery
        {
            PageRequest = pageRequest,
            DynamicQuery = dynamicQuery,
            UserId = userId
        };

        PaginatedList<GetReportTemplateDto> result = await mediator.Send(query);
        return Ok(result);
    }
}