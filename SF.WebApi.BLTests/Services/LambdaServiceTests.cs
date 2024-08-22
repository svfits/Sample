using SF.WebApi.BL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SF.WebApi.BL.Services.Tests;

[TestClass()]
public class LambdaServiceTests
{
    [TestMethod()]
    public void RunTest()
    {
        //arrange
        var lambdaService = new LambdaService();

        //action
        lambdaService.RunAction();

        //assert        
    }

    [TestMethod()]
    public void RunFuncTest()
    {
        //arrange
        var lambdaService = new LambdaService();

        //action
        lambdaService.RunFunc();

        //assert

        var dtStart = new DateTime(2021, 10, 12);
        var dtEnd = new DateTime(2024, 8, 22);
        var result = (dtEnd - dtStart).TotalDays;

    }

    [TestMethod("Сколько дней ипотеки")]
    public void RangeDays()
    {
        //arrange
        var dtStart = new DateTime(2021, 10, 12);
        var dtEnd = new DateTime(2024, 8, 22);

        //action
        var result = (dtEnd - dtStart).TotalDays;

        //assert
        Assert.AreEqual(1045, result);
    }
}