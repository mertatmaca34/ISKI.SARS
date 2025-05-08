using ISKI.SARS.Application.Features.Tags.Commands.CreateTag;
using ISKI.SARS.Application.Features.Tags.Dtos;
using ISKI.SARS.Application.Features.Tags.Queries.GetTagById;
using ISKI.SARS.Application.Features.Tags.Queries.GetTags;
using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagsController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTagCommand command)
    {
        GetTagDto result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [Authorize(Roles = "Admin,Operator")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetTagByIdQuery { Id = id };
        GetTagDto result = await mediator.Send(query);
        return Ok(result);
    }

    [Authorize(Roles = "Admin,Operator")]
    [HttpPost("list")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery)
    {
        var query = new GetTagsQuery
        {
            PageRequest = pageRequest,
            DynamicQuery = dynamicQuery
        };

        PaginatedList<GetTagDto> result = await mediator.Send(query);
        return Ok(result);
    }
}
