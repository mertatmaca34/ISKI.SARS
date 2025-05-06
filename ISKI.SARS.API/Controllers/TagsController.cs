using ISKI.SARS.Application.Features.Tags.Commands.CreateTag;
using ISKI.SARS.Application.Features.Tags.Dtos;
using ISKI.SARS.Application.Features.Tags.Queries.GetTagById;
using ISKI.SARS.Application.Features.Tags.Queries.GetTags;
using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TagsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST: api/tags
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTagCommand command)
    {
        GetTagDto result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    // GET: api/tags/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetTagByIdQuery { Id = id };
        GetTagDto result = await _mediator.Send(query);
        return Ok(result);
    }

    // POST: api/tags/list
    [HttpPost("list")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery)
    {
        var query = new GetTagsQuery
        {
            PageRequest = pageRequest,
            DynamicQuery = dynamicQuery
        };

        PaginatedList<GetTagDto> result = await _mediator.Send(query);
        return Ok(result);
    }
}
