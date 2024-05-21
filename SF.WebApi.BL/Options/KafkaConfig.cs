namespace SF.WebApi.BL.Options;

public class KafkaConfig
{
    public string BootstrapServers { get; init; } = null!;

    public string Topic { get; set; } = null!;

    public string GroupId { get; set; } = null!;
}
