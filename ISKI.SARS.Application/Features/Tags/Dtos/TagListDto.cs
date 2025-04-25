namespace ISKI.SARS.Application.Features.Tags.Dtos;

public class TagListDto
{
    public List<GetTagDto> Items { get; set; } = new();
    public int TotalCount => Items.Count;
}
