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
    /// Отправка в кафку простого числа
    /// </summary>
    /// <example name="number">22222</example>
    /// <param name="number">Просто число</param>
    /// <returns>Тут число должно быть!</returns>
    [HttpPost]
    public async Task<int> SendToKafka(int number)
    {
        _logger.LogTrace("Поступили данные для Kafka {number}", number);

        await _kafkaService.SendToKafka(number);        

        return number;
    }
}
