using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SF.WebApi.BL.Services.Tests;

[TestClass()]
public class ReferenceServiceTests
{
    [TestMethod("Поведение строк и ссылочных типов")]
    public void StartTest()
    {
        //arrange
        

        //action
        (string strResult, ReferenceService obj) = ReferenceService.Start();

        //assert
        Assert.AreEqual(strResult, "до изменения");
        Assert.AreEqual(obj.MyProperty, 99995);
    }
}