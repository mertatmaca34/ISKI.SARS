using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly ITagRepository _tagRepository;

    public TagsController(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tags = await _tagRepository.GetAllAsync();
        return Ok(tags);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Tag tag)
    {
        await _tagRepository.AddAsync(tag);
        return Ok();
    }
}
