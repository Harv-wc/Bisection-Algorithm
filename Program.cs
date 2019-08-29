using System;
using System.Collections.Generic;

namespace Bisection_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintTest();
            Console.WriteLine("\n__________________________________\n");
            HumanPlays NewGame = new HumanPlays { };
            NewGame.StartGame();
            Console.WriteLine("\n__________________________________\n");
            ComputerPlays NewGame2 = new ComputerPlays { };
            NewGame2.StartGame();
            Console.WriteLine("\n__________________________________\n");
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

    class HumanPlays
    {
        public void StartGame()
        {
            Random rand = new Random();
            int computerNum = rand.Next(1000);
            bool correctGuess = false;
            int guessCount = 0;
            Console.Write("Welcome to the Number Guess game!\n\n" +
                "The computer chose a random number between 1 and 1000.\n" +
                "Guess that number: ");
            int humanNum = Convert.ToInt32(Console.ReadLine());
            while (correctGuess == false)
            {
                if (humanNum == computerNum)
                {
                    Console.WriteLine($"Correct! You guessed the right number! Number of attempts: {guessCount}");
                    correctGuess = true;
                }

                if (humanNum > computerNum)
                {
                    guessCount++;
                    Console.WriteLine("Oops! Your guess was too high. Try again: ");
                    humanNum = Convert.ToInt32(Console.ReadLine());
                }
                if (humanNum < computerNum)
                {
                    guessCount++;
                    Console.WriteLine("Oops! Your guess was too low. Try again: ");
                    humanNum = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
    } // play game: Computer randoms number 1 - 1000 (Human performs bisection to pick a guessing number in shortest amount of guesses)

    class ComputerPlays
    {
        public void StartGame()
        {
            int[] numbers = FillNumbers();
            Console.WriteLine("Pick a number between 1 and 100 and computer will guess your number!\nPress any key when ready... ");
            Console.ReadKey();
            int indexValue = (numbers.Length - 1) / 2;
            int computerNum; 
            int yesNo;
            int leftIndex = 0;
            int rightIndex = numbers.Length - 1;
            int guessCount = 0;
            bool isCorrect = false;
            while (isCorrect != true)
            {
                computerNum = numbers[indexValue];
                // is computerNum correct?
                Console.WriteLine($"Computer guesses: [{computerNum}]... Is that correct?\n" +
                    $"1. Yes!\n" +
                    $"2. No, that's too low.\n" +
                    $"3. No, that's too high.\n");
                yesNo = Convert.ToInt32(Console.ReadLine());
                switch(yesNo)
                {
                    case 1:
                        Console.WriteLine($"Awesome! The computer correctly guessed your number as [{computerNum}].\nAttempts to guess correctly: {guessCount}");
                        isCorrect = true;
                        Console.ReadKey();
                        break;
                    case 2:
                        leftIndex = indexValue;
                        indexValue = (leftIndex + rightIndex) / 2;
                        guessCount++;
                        Console.Clear();
                        break;
                    case 3:
                        rightIndex = indexValue;
                        indexValue = (leftIndex + rightIndex) / 2;
                        guessCount++;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Please select 1, 2, or 3.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }

        }
        private static int[] FillNumbers()
        { int[] numbers = new int[99];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = i+1;
            return numbers;}

    } // computer plays game. Human picks number from 1 - 100. computer will continually guess a number until it gets it.
}
