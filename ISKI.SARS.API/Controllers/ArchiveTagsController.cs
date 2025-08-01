using ISKI.SARS.Application.Features.ArchiveTags.Commands.CreateArchiveTag;
using ISKI.SARS.Application.Features.ArchiveTags.Commands.UpdateArchiveTag;
using ISKI.SARS.Application.Features.ArchiveTags.Commands.DeleteArchiveTag;
using ISKI.SARS.Application.Features.ArchiveTags.Dtos;
using ISKI.SARS.Application.Features.ArchiveTags.Queries.GetArchiveTagById;
using ISKI.SARS.Application.Features.ArchiveTags.Queries.GetArchiveTags;
using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArchiveTagsController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateArchiveTagCommand command)
    {
        GetArchiveTagDto result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateArchiveTagCommand command)
    {
        GetArchiveTagDto result = await mediator.Send(command);
        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteArchiveTagCommand { Id = id };
        GetArchiveTagDto result = await mediator.Send(command);
        return Ok(result);
    }

    [Authorize(Roles = "Admin,Operator")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetArchiveTagByIdQuery(id);
        GetArchiveTagDto result = await mediator.Send(query);
        return Ok(result);
    }

    [Authorize(Roles = "Admin,Operator")]
    [HttpPost("list")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery)
    {
        var query = new GetArchiveTagListQuery
        {
            PageRequest = pageRequest,
            DynamicQuery = dynamicQuery
        };
        PaginatedList<GetArchiveTagDto> result = await mediator.Send(query);
        return Ok(result);
    }
}
