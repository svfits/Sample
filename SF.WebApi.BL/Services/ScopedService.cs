using Microsoft.Extensions.Logging;

namespace SF.WebApi.BL.Services;

public interface IScopedService
{
    int Start();
}

public class ScopedService(ILogger<ScopedService> logger) : IScopedService
{
    private readonly ILogger<ScopedService> _logger = logger;
    private int i;

    public int Start()
    {
        i++;
        _logger.LogInformation("Работает старт {i}", i);
        return i;
    }
}
