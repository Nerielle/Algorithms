using System;
using System.Collections.Generic;

namespace MergeSort
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var array = new[] { 2, 7, 4, 8, 9, 0, 3, 1, 5, 6 };
            var result = Sort(array);
            Console.WriteLine(string.Join(",", result));
            Console.ReadLine();
        }

        private static int[] Sort(int[] array)
        {
            if (array.Length > 1)
            {
                var middle = array.Length / 2;
                var firstArray = new int[middle];
                var secondArray = new int[array.Length - middle];
                Array.Copy(array, 0, firstArray, 0, middle);
                Array.Copy(array, middle, secondArray, 0, array.Length - middle);
                var firstSorted = Sort(firstArray);
                var secondSorted = Sort(secondArray);
                var result = new int[array.Length];
                int i = 0;
                int j = 0;
                for (int index = 0; index < array.Length; index++)
                {
                    if (j < secondSorted.Length && i < firstSorted.Length)
                    {
                        if (firstSorted[i] < secondSorted[j])
                        {
                            result[index] = firstSorted[i];
                            i++;
                            continue;
                        }
                        result[index] = secondSorted[j];
                        j++;
                        continue;
                    }
                    if (i < firstSorted.Length)
                    {
                        result[index] = firstSorted[i];
                        i++;
                    }
                    if (j < secondSorted.Length)
                    {
                        result[index] = secondSorted[j];
                        j++;
                    }

                }
                return result;

            }
            return array;
        }
    }
}