using System.Diagnostics;

namespace SF.WebApi.BL.Services;

public interface ITasksService
{
    List<int> Run();

    void RunParallel();
    Task RunSequentially();
}

public class TasksService : ITasksService
{
    public List<int> Run()
    {
        var list = new List<int>() { 10, 20, 30, 40 };
        int i = 10;
        var query = list.Where(x => x >= i);
        i = 25;
        var result = query.ToList();
        list.Clear();

        return result;
    }

    public void RunParallel()
    {
        Debug.WriteLine("Запуск параллельно");
        var list = new List<Task>();

        for (int i = 0; i < 10; i++)
        {
            var t = i;
            var task = Task.Run(() => Start(t));
            list.Add(task);
        }

        Task.WaitAll(list.ToArray());

        foreach (var item in list)
        {
            item.Start();
            //Debug.WriteLine($"Запуск параллельно {item.}");
        }
    }

    private static async Task<int> Start(int i)
    {
        Debug.WriteLine("Ждем паузы " + DateTime.Now + " " + i);
        await Task.Delay(2000);
        return i * 10;
    }

    public async Task RunSequentially()
    {
        Debug.WriteLine("Запуск последовательно");

        for (int i = 0; i < 10; i++)
        {
            await Start(i);
        }
    }
}
