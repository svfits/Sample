using Microsoft.EntityFrameworkCore.Query;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SF.WebApi.BL.Services.Tests;

[TestClass()]
public class MainServiceTests
{
    [TestMethod("Основной метод, запуск")]
    public void RunTest()
    {
        //arrange
        var mainService = new MainService();

        //action
        var result = mainService.Run();

        //assert
        Assert.AreEqual(result.First(), 15);
        Assert.AreEqual(result.Last(), 20);
    }
}