using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace SF.WebApi.BL.Services.Tests;

[TestClass()]
public class InsertionSortServiceTests
{
    [TestMethod("Сортировка вставками")]
    public void StartTest()
    {
        //arrange
        var insertionSortService = new InsertionSortService();
        int[] numbers = [127, 21, 211, 12, 21, 23, 312, 42456, 5, 67789, 78];

        //action
        var result = insertionSortService.Start(numbers);

        //assert
        foreach (var item in result)
        {
            Debug.WriteLine(item);
        }
    }
}