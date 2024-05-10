using System.Diagnostics;

namespace SF.WebApi.BL.Services;

public class TaskSynchronizationService
{
    public static int MyProperty = 1;

    private static readonly SemaphoreSlim semaphor = new(1, 1);

    private static async Task StartIteration(int i)
    {
        await semaphor.WaitAsync();

        Debug.WriteLine(i);
        await Task.Delay(500);
        MyProperty *= i;

        semaphor.Release(); 
    }

    public static void Run()
    {
        var list = new List<Task>();
        for (int i = 1; i < 10; i++)
        {
            var t = i;
            var task = Task.Run(() => StartIteration(t));
            list.Add(task);
        }

        Task.WaitAll(list.ToArray());
    }
}
