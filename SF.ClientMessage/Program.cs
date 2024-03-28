namespace SF.ClientMessage;

internal class Program
{
    static async Task Main()
    {
        Console.WriteLine("Нажми на кнопку получишь результат!");
        Console.ReadLine();

        HttpClient client = new()
        {
            BaseAddress = new Uri("http://localhost:5194/")
        };

        var clientMessage = new Clients.ClientMessage(client);
        await clientMessage.ScopedAsync();

        Console.WriteLine("Hello, World!");
    }
}
