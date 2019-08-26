using System;
using System.Collections.Generic;

namespace Bisection_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int indexValue;
            // Test Case 1: Does Exist
            int[] array1 = new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            Bisection Array1Val5 = new Bisection(array1, 5);
            indexValue = Array1Val5.FindIndex();
            if (indexValue == -1)
                Console.WriteLine($"5 does not exist in array1.");
            else
                Console.WriteLine($"5 exists at array1 index: {indexValue}\n");
            //Test Case 2: DOes Not Exist
            int[] array2 = new int[] { 6, 12, 43, 47, 51, 56, 87, 98, 109, 210, 411, 442, 472, 514, 575, 616 };
            Bisection Array2Val473 = new Bisection(array2, 473);
            indexValue = Array2Val473.FindIndex();
            if (indexValue == -1)
                Console.WriteLine($"473 does not exist in array1.");
            else
                Console.WriteLine($"473 exists at array2 index: {indexValue}\n");
        }
    }
    class Bisection
    {
        public int[] GivenArray { get; set; }
        public int SearchValue { get; set; }
        public int LowIndex { get; set; }
        public int HighIndex { get; set; }
        public const int startIndex = -5;

        public Bisection(int[] givenArray, int searchValue)
        {
            this.GivenArray = givenArray;
            this.SearchValue = searchValue;
            this.LowIndex = 0;
            this.HighIndex = givenArray.Length - 1;
        }
        public int FindIndex(int index = startIndex)
        {
            if (index == startIndex)
                index = (GivenArray.Length - 1) / 2;
            // exit logic:
            if (index == 1) // return an index and exit at min array index
            {
                if (SearchValue == GivenArray[1])
                    return 1;
                else if (SearchValue == GivenArray[0])
                    return 0;
                else return -1;
            }
            if (index == GivenArray.Length-2) // return an index and exit at max array index
            {
                if (SearchValue == GivenArray[index])
                    return index;
                else if (SearchValue == GivenArray[index + 1])
                    return index + 1;
                else return -1;
            }
            // Bisection logic:
            if (SearchValue == GivenArray[index])
                return index;
            else if (SearchValue < GivenArray[index])
            {
                // TODO
                HighIndex = index;
                index = (LowIndex + index) / 2;
                if (index == HighIndex)
                    return -1;
                else
                    return FindIndex(index);
            }
            else if (SearchValue > GivenArray[index])
            {
                LowIndex = index;
                index = (HighIndex + index) / 2;
                if (index == LowIndex)
                    return -1;
                else
                    return FindIndex(index);
            }
            else // Should probably use throw new exception...
            {
                Console.WriteLine($"Something went wrong looking for {SearchValue}...");
                Console.ReadLine();
                return -2;
            }
        }
    }
}
