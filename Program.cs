using System;
using System.Collections.Generic;

namespace Bisection_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintTest();
            
        }

        private static void PrintTest()
        {
            // Test Case 1: Does Exist
            int indexValue;
            Console.WriteLine("Exist and Does Not Exist Test Case:");
            int[] array1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            Bisection Array1Val5 = new Bisection(array1, 5);
            indexValue = Array1Val5.FindIndex();
            if (indexValue == -1)
                Console.WriteLine($"5 does not exist in array1.");
            else
                Console.WriteLine($"5 exists at array1 index: {indexValue}");
            //Test Case 2: Does Not Exist
            int[] array2 = new int[] { 6, 12, 43, 47, 51, 56, 87, 98, 109, 210, 411, 442, 472, 514, 575, 616 };
            Bisection Array2Val473 = new Bisection(array2, 473);
            indexValue = Array2Val473.FindIndex();
            if (indexValue == -1)
                Console.WriteLine($"473 does not exist in array2.");
            else
                Console.WriteLine($"473 exists at array2 index: {indexValue}");
        } // try and break logic here...
    }
}
