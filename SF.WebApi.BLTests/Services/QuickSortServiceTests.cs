using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace SF.WebApi.BL.Services.Tests;

[TestClass()]
public class QuickSortServiceTests
{
    [TestMethod("Быстрая сортировка")]
    public void StartTest()
    {
        //arrange
        var quickSortService = new QuickSortService();
        int[] numbers = [1232, 22, 23, 43, 51, 63, 7, 85, 19, 101, 1122];

        //action
        var result = quickSortService.Start(numbers);

        //assert
        foreach (var item in result)
        {
            Debug.WriteLine(item);
        }
    }
}