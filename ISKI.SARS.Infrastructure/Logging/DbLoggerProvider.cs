using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ISKI.SARS.Infrastructure.Logging;

public class DbLoggerProvider(IServiceScopeFactory scopeFactory) : ILoggerProvider
{
    private readonly IServiceScopeFactory _scopeFactory = scopeFactory;

    public ILogger CreateLogger(string categoryName) => new DbLogger(_scopeFactory, categoryName);

    public void Dispose() { }
}

public class DbLogger(IServiceScopeFactory scopeFactory, string categoryName) : ILogger
{
    private readonly IServiceScopeFactory _scopeFactory = scopeFactory;
    private readonly string _category = categoryName;

    public IDisposable BeginScope<TState>(TState state) => default!;

    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        var message = formatter(state, exception);
        using var scope = _scopeFactory.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<ILogRepository>();
        var entry = new LogEntry
        {
            Level = MapLevel(logLevel),
            Message = message,
            Detail = exception?.ToString(),
            CreatedAt = DateTime.Now
        };
        repo.AddAsync(entry).GetAwaiter().GetResult();
    }

    private static ISKI.SARS.Domain.Enums.LogLevel MapLevel(LogLevel level)
    {
        return level switch
        {
            LogLevel.Trace => ISKI.SARS.Domain.Enums.LogLevel.Trace,
            LogLevel.Debug => ISKI.SARS.Domain.Enums.LogLevel.Debug,
            LogLevel.Information => ISKI.SARS.Domain.Enums.LogLevel.Info,
            LogLevel.Warning => ISKI.SARS.Domain.Enums.LogLevel.Warn,
            LogLevel.Error => ISKI.SARS.Domain.Enums.LogLevel.Error,
            LogLevel.Critical => ISKI.SARS.Domain.Enums.LogLevel.Fatal,
            _ => ISKI.SARS.Domain.Enums.LogLevel.Info
        };
    }
}

public static class DbLoggerExtensions
{
    public static ILoggingBuilder AddDatabaseLogger(this ILoggingBuilder builder)
    {
        builder.Services.AddSingleton<ILoggerProvider, DbLoggerProvider>();
        return builder;
    }
}
