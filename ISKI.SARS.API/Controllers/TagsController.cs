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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tags = await _tagRepository.GetAllAsync();
        var result = _mapper.Map<List<TagDto>>(tags);
        return Ok(result);
    }
}
