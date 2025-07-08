namespace ISKI.SARS.WebUI.Models;

public class Response<T>
{
    public bool IsSuccess { get; set; }
    public T? Data { get; set; }
    public Dictionary<string, string[]>? Errors { get; set; }
}
