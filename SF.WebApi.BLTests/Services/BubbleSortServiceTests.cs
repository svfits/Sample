using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace SF.WebApi.BL.Services.Tests;

[TestClass()]
public class BubbleSortServiceTests
{
    [TestMethod("Пузырьковая сортировка")]
    public void StartTest()
    {
        //arrange
        var bubbleSortService = new BubbleSortService();
        int[] numbers = [12, 32, 23, 2, 3, 432, 54, 345, 34, 5, 456, 45, 5, 3543];

        //action
        bubbleSortService.Start(numbers);

        //assert

        foreach (int number in numbers)
        {
            Debug.WriteLine(number);
        }
    }
}