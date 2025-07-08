using ISKI.Core.CrossCuttingConcerns.Exceptions.ExceptionHandling;

namespace ISKI.SARS.WebUI.Services;

public class ApiResult<T>
{
    public bool Success { get; }
    public T? Data { get; }
    public ErrorResponse? Error { get; }

    public ApiResult(T? data)
    {
        Success = true;
        Data = data;
    }

    public ApiResult(ErrorResponse error)
    {
        Success = false;
        Error = error;
    }
}
