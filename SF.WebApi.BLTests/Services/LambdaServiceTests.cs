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
    }
}