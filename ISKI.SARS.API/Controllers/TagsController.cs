using AutoMapper;
using ISKI.SARS.Application.Features.Tags.Dtos;
using ISKI.Core.Domain.Common.Models;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using ISKI.Core.Infrastructure.Paging;
using ISKI.Core.CrossCuttingConcerns.ExceptionHandling; // Bunu da ekle (ErrorResponse için)

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

        var dtoResult = _mapper.Map<GetTagDto>(result);
        return CreatedAtAction(nameof(GetById), new { id = dtoResult.Id }, dtoResult);
    }

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var tag = await _tagRepository.GetByIdAsync(id);
        if (tag == null)
            throw new NotFoundException("Tag not found."); // Özel bir exception atıyoruz

        var result = _mapper.Map<GetTagDto>(tag);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTagDto dto)
    {
        if (id != dto.Id)
            throw new BadRequestException("URL ID ile body ID uyuşmuyor.");

        var entity = _mapper.Map<Tag>(dto);
        entity.UpdatedAt = DateTime.UtcNow;

        var updated = await _tagRepository.UpdateAsync(entity);
        var result = _mapper.Map<UpdateTagDto>(updated);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _tagRepository.DeleteAsync(id);
        if (deleted == null)
            throw new NotFoundException("Tag not found for deletion.");

        var result = _mapper.Map<DeleteTagDto>(deleted);
        return Ok(result);
    }
}
