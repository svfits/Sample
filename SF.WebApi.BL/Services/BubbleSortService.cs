using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.WebApi.BL.Services;

public interface IBubbleSortService
{
    int[] Start(int[] numbers);
}

public class BubbleSortService : IBubbleSortService
{
    public int[] Start(int[] numbers)
    {
        int temp;
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length - 1 - i; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }
            }
        }

        return numbers;
    }
}
