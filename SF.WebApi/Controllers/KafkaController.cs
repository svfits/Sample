using Microsoft.AspNetCore.Mvc;
using SF.WebApi.BL.Services;
using System.Net.Mime;

namespace SF.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public class KafkaController(ILogger<KafkaController> logger, IKafkaService kafkaService) : ControllerBase
{
    private readonly ILogger<KafkaController> _logger = logger;
    private readonly IKafkaService _kafkaService = kafkaService;

    /// <summary>
    /// Отправка в кафку строки
    /// </summary>
    /// <param name="message">Просто строка</param>
    /// <returns>Тут должна быть строка!</returns>
    [HttpPost]
    public async Task<string> SendToKafka(string message = "message")
    {
        _logger.LogTrace("Поступили данные для Kafka {number}", message);

        await _kafkaService.SendToKafka(message);        

        return message;
    }
}
