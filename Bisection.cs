using System;
using System.Collections.Generic;
using System.Text;

namespace Bisection_Algorithm
{

    class Bisection // Can take in any size array of sorted ints and tell you the index location of a specific number.
    {
        public int[] GivenArray { get; set; }
        public int SearchValue { get; set; }
        public int LowIndex { get; set; }
        public int HighIndex { get; set; }
        public const int startIndex = -5; // I'm using -5 just because it's an unused and unexpected value. It's just a place holder to be replaced in the method so I can generate a starting point on an undefined array.

        public Bisection(int[] givenArray, int searchValue) // When you create an instance of the class, that's when you'll pass in the array and search value. Each instance does it's own search
        {
            this.GivenArray = givenArray;
            this.SearchValue = searchValue;
            this.LowIndex = 0;
            this.HighIndex = givenArray.Length - 1;
        }
        public int FindIndex(int index = startIndex) // passed at class construction. Just call FindIndex for that class object. See the Print Test Case function in Program.cs
        {
            // This is needed so I can set the starting index to the center of the array. (GivenArray.Length - 1) / 2 is not a compile-time constant
            if (index == startIndex)
                index = (GivenArray.Length - 1) / 2;
            //-------------------------------------------//
            // exit logic:
            if (index == 0 && SearchValue == GivenArray[0]) // handles an array of 1 object.
                return index;
            if (index == 0 && SearchValue != GivenArray[0])
                return -1;
            if (index == 1) // return an index and exit at min array index. Performs checks on first and second position of the array.
            {
                if (SearchValue == GivenArray[1])
                    return 1;
                else if (SearchValue == GivenArray[0])
                    return 0;
                else return -1;         // I'm using return -1 to indicate that the value doesn't exist. Some of these probably aren't needed -- like this one. But I use it as a catch for unpredicted results just to be safe.
            }
            if (index == GivenArray.Length - 2) // return an index and exit at max array index. Performs checks on last and second to last position of array.
            {
                if (SearchValue == GivenArray[index])
                    return index;
                else if (SearchValue == GivenArray[index + 1])
                    return index + 1;
                else return -1;
            }
            //-------------------------------------------//
            // Bisection logic:
            if (SearchValue == GivenArray[index]) // returns the index if the center check is correct
                return index;
            else if (SearchValue < GivenArray[index]) // if the value we want is less than the center check value in array.
            {
                HighIndex = index;      // High index is the right-most (highest value) that we know the search value is not higher than. If the search value is less than the current index, we then know that the current index is the new highest value. Search value will not appear beyond current index.
                index = (LowIndex + index) / 2; // sets new center check point
                if (index == HighIndex)     // This is important to return -1 if true to avoid infinite loop if the number does not exist. otherwise it will jump back and forth from this logic to the one below.
                    return -1;
                else
                    return FindIndex(index);
            }
            else if (SearchValue > GivenArray[index]) // same logic as above only if the search value is greater than our check point
            {
                LowIndex = index;
                index = (HighIndex + index) / 2;
                if (index == LowIndex)
                    return -1;
                else
                    return FindIndex(index);
            }
            //-------------------------------------------//
            // Just in case... If anything is able to get down to this point, it's by some logic I didn't catch above and will have to figure out. There shouldn't be anything that reaches this far down.
            else // Should probably use throw new exception...
            {
                Console.WriteLine($"Something went wrong looking for {SearchValue}...\n" +
                    $"Stopped at index value {index}...");
                Console.ReadLine();
                return -2; // Not using -2 so it's an unexpected value I chose. Could be anything.
            }
        }
    }
}
