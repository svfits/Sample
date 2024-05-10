namespace SF.WebApi.BL.Services;

public interface IKafkaService
{
    Task<int> SendToKafka(int number);
}

public class KafkaService : IKafkaService
{
    public async Task<int> SendToKafka(int number)
    {
        return number;
    }
}
