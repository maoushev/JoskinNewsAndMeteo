using Serilog;
using Serilog.Sinks.File;

public static class Log
{
    private static ILogger? _logger;

    public static void Initialize(string filePath)
    {
        _logger = new LoggerConfiguration()
            .WriteTo.File(filePath)
            .CreateLogger();
    }

    public static void Error(string message)
    {
        if (_logger != null)
            _logger.Error(message);
    }

    public static void CloseAndFlush()
    {
        Log.CloseAndFlush();
    }
}