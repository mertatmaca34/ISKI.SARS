using AutoMapper;
using ISKI.SARS.Application.Features.Tags.Dtos;
using ISKI.Core.Domain.Common.Models;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using ISKI.Core.Infrastructure.Paging;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;

    public TagsController(ITagRepository tagRepository, IMapper mapper)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
    }

    //POST/api/tags
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTagDto dto)
    {
        var entity = _mapper.Map<Tag>(dto);
        entity.CreatedAt = DateTime.UtcNow;

        var result = await _tagRepository.AddAsync(entity);

        var dtoResult = _mapper.Map<GetTagDto>(result);
        return CreatedAtAction(nameof(GetById), new { id = dtoResult.Id }, dtoResult);
    }

    // GET /api/tags
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PageRequest paginationQuery)
    {
        var tags = await _tagRepository.GetAllAsync(paginationQuery.PageNumber, paginationQuery.PageSize);
        var mappedItems = _mapper.Map<List<GetTagDto>>(tags.Items);

        var pagedResult = new PaginatedList<GetTagDto>
        {
            Items = mappedItems,
            Index = tags.Index,
            Size = tags.Size,
            Count = tags.Count,
            Pages = tags.Pages
        };

        return Ok(pagedResult);
    }

    // GET /api/tags/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var tag = await _tagRepository.GetByIdAsync(id);
        if (tag == null) return NotFound();

        var result = _mapper.Map<GetTagDto>(tag);
        return Ok(result);
    }

    // PUT /api/tags/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTagDto dto)
    {
        if (id != dto.Id)
            return BadRequest("URL ile gövde ID eşleşmiyor.");  

        var entity = _mapper.Map<Tag>(dto);
        entity.UpdatedAt = DateTime.UtcNow;

        var updated = await _tagRepository.UpdateAsync(entity);
        var result = _mapper.Map<UpdateTagDto>(updated);

        return Ok(result);
    }

    // DELETE /api/tags/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _tagRepository.DeleteAsync(id);
        if (deleted == null) return NotFound();

        var result = _mapper.Map<DeleteTagDto>(deleted);
        return Ok(result);
    }
}
