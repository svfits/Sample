using Confluent.Kafka;
using Microsoft.Extensions.Options;
using SF.WebApi.BL.Options;
using System.Diagnostics;

namespace SF.WebApi.BL.Services;

public interface IKafkaService
{
    Task SendToKafka(string number);
}

public class KafkaService(IOptions<KafkaConfig> kafkaOptions) : IKafkaService
{
    private readonly ProducerConfig config = new() { BootstrapServers = kafkaOptions.Value.BootstrapServers };

    public async Task SendToKafka(string message)
    {
        using var producer = new ProducerBuilder<Null, string>(config).Build();
        try
        {
            await producer.ProduceAsync(kafkaOptions.Value.Topic, new Message<Null, string> { Value = message });
            Debug.WriteLine("Что то отправилось в кафку");
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Ошибка при отправке в кафку! " + ex);
        }
    }
}
