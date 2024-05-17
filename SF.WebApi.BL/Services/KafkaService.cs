using Confluent.Kafka;
using System.Diagnostics;

namespace SF.WebApi.BL.Services;

public interface IKafkaService
{
    Task SendToKafka(string number);
}

public class KafkaService : IKafkaService
{
    private readonly ProducerConfig config = new() { BootstrapServers = "kafka1:9092" };
    private readonly string topic = "simpletalk_topic";


    public async Task SendToKafka(string message)
    {
        using var producer = new ProducerBuilder<Null, string>(config).Build();
        try
        {
            await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
            Debug.WriteLine("Что то отправилось в кафку");
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Ошибка при отправке в кафку! " + ex);
        }
    }
}
