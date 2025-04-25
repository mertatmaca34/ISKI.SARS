using AutoMapper;
using ISKI.SARS.Application.Features.Tags.Dtos;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTagDto dto)
    {
        var entity = _mapper.Map<Tag>(dto);
        entity.CreatedAt = DateTime.UtcNow;

        var result = await _tagRepository.AddAsync(entity);
        return Created("", result);
    }

    // GET /api/tags
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tags = await _tagRepository.GetAllAsync();
        var result = _mapper.Map<List<TagDto>>(tags);
        return Ok(result);
    }

    // GET /api/tags/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var tag = await _tagRepository.GetByIdAsync(id);
        if (tag == null) return NotFound();

        var result = _mapper.Map<TagDto>(tag);
        return Ok(result);
    }

    // POST /api/tags
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTagDto dto)
    {
        var entity = _mapper.Map<Tag>(dto);
        entity.Id = Guid.NewGuid();
        entity.CreatedAt = DateTime.UtcNow;

        var result = await _tagRepository.AddAsync(entity);
        var dtoResult = _mapper.Map<TagDto>(result);

        return CreatedAtAction(nameof(GetById), new { id = dtoResult.Id }, dtoResult);
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
        var result = _mapper.Map<TagDto>(updated);

        return Ok(result);
    }

    // DELETE /api/tags/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _tagRepository.DeleteAsync(id);
        if (deleted == null) return NotFound();

        var result = _mapper.Map<TagDto>(deleted);
        return Ok(result);
    }
}