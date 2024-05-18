
using Confluent.Kafka;
using System.Diagnostics;

namespace SF.WebApi.BackgroundServices;

public class KafkaConsumerHandler(ILogger<KafkaConsumerHandler> logger) : IHostedService, IDisposable
{
    private readonly string topic = "simpletalk_topic";
    private readonly CancellationTokenSource _stoppingCts = new();

    public Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Должен работать сервис");

        Task.Run(() => ExecuteAsync(_stoppingCts.Token));

        return Task.CompletedTask;
    }

    private void ExecuteAsync(CancellationToken token)
    {
        var conf = new ConsumerConfig
        {
            GroupId = "st_consumer_group",
            BootstrapServers = "kafka1:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var builder = new ConsumerBuilder<Ignore, string>(conf).Build();
        builder.Subscribe(topic);
        try
        {
            while (true)
            {
                var consumer = builder.Consume(token);
                Debug.WriteLine($"Message: {consumer.Message.Value} received from {consumer.TopicPartitionOffset}");
            }
        }
        catch (Exception)
        {
            builder.Close();
        }
    }

    public virtual Task StopAsync(CancellationToken cancellationToken)
    {
        try
        {
            // Signal cancellation to the executing method
            _stoppingCts.Cancel();
        }
        finally
        {
            logger.LogInformation("Стоп приема от Kafka");
        }
        return Task.CompletedTask;
    }

    public virtual void Dispose() => _stoppingCts.Cancel();
}
