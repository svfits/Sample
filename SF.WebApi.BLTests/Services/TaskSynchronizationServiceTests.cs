using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace SF.WebApi.BL.Services.Tests;

[TestClass()]
public class TaskSynchronizationServiceTests
{
    [TestMethod()]
    public void RunTest()
    {
        //arrange

        //action
        TaskSynchronizationService.Run();

        //assert
        Debug.WriteLine("Ответ: " + TaskSynchronizationService.MyProperty);      
    }
}