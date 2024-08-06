using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SF.WebApi.BL.Services.Tests;

[TestClass()]
public class TasksServiceTests
{
    [TestMethod("Основной метод, запуск")]
    public void RunTest()
    {
        //arrange
        var tasksService = new TasksService();

        //action
        var result = tasksService.Run();

        //assert
        Assert.AreEqual(result.First(), 30);
        Assert.AreEqual(result.Last(), 40);
    }

    [TestMethod("Запуск параллельно")]
    public void RunParallel()
    {
        //arrange
        var tasksService = new TasksService();

        //action
        tasksService.RunParallel();

        //assert        
    }

    [TestMethod("Запуск последовательно")]
    public async Task RunSequentiallyTest()
    {
        //arrange
        var tasksService = new TasksService();

        //action
        await tasksService.RunSequentially();

        //assert
    }
}