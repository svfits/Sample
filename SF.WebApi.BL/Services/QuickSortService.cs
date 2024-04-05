using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.WebApi.BL.Services;

public interface IQuickSortService
{
    int[] Start(int[] numbers);
}

/// <summary>
/// Быстрая сортировка
/// Находим опорный элемент
/// Перемещаем те что меньше его перед ним изменяя его индекс
/// </summary>
public class QuickSortService : IQuickSortService
{
    public int[] Start(int[] numbers)
    {
        numbers = QuickSort(numbers, 0, numbers.Length - 1);

        return numbers;
    }

    private static int FindPivot(int[] numbers, int minIndex, int maxIndex)
    {
        int pivot = minIndex - 1;
        int temp;
        for (int i = minIndex; i < maxIndex; i++)
        {
            if (numbers[i] < numbers[maxIndex])
            {
                pivot++;
                temp = numbers[pivot];
                numbers[pivot] = numbers[i];
                numbers[i] = temp;
            }
        }

        pivot++;
        temp = numbers[pivot];
        numbers[pivot] = numbers[maxIndex];
        numbers[maxIndex] = temp;

        return pivot;
    }

    private static int[] QuickSort(int[] numbers, int minIndex, int maxIndex)
    {
        if (minIndex >= maxIndex)
        {
            return numbers;
        }

        int pivot = FindPivot(numbers, minIndex, maxIndex);
        QuickSort(numbers, minIndex, pivot - 1);
        QuickSort(numbers, pivot + 1, maxIndex);

        return numbers;
    }
}
