using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.WebApi.BL.Services;

public interface IInsertionSortService
{
    int[] Start(int[] numbers);
}

public class InsertionSortService : IInsertionSortService
{
    public int[] Start(int[] numbers)
    {
        int index;
        int currentNumber;

        for (int i = 0; i < numbers.Length; i++)
        {
            index = i;
            currentNumber = numbers[i];

            while (index > 0 && currentNumber < numbers[index - 1])
            {
                numbers[index] = numbers[index - 1];
                index--;
            }
            numbers[index] = currentNumber;
        }

        return numbers;
    }
}
