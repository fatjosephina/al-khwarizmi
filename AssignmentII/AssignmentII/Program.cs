using System;

namespace AssignmentII
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H" };
            letters.DoFisherYatesShuffle();
            letters.WriteStringArray();
            letters.DoFisherYatesAlternativeShuffle();
            letters.WriteStringArray();
        }
    }

    public static class StringWriter
    {
        // I extracted this logic into a method in its own extension class so I can easily do it multiple times
        public static void WriteStringArray(this object[] stringArray)
        {
            foreach (string stringToWrite in stringArray)
            {
                Console.Write(stringToWrite + " ");
            }
            // I also added a new line so it is easier to distinguish between the two visually
            Console.WriteLine("\n");
        }
    }

    // This class demonstrates the Fisher-Yates shuffle algorithm in two different ways, it uses an extension method in the Swapper class to swap between values at indices
    // based on a random number generated in the GetRandomNumberBetweenZeroAndI() method
    public static class FisherYatesShuffler
    {
        private static Random randomNumber = new Random();
        
        public static void DoFisherYatesShuffle(this object[] objects)
        {
            for (int i = objects.Length - 1; i > 0; i--)
            {
                // Personally, I would not remove j because it is easier to understand that i and j are being swapped rather than i and GetRandomNumber(i) being swapped
                // i and j could also be replaced with something more human-readable like firstNumber and secondNumber
                int j = GetRandomNumberBetweenZeroAndI(i);
                objects.SwapValuesAtIndices(i, j);
            }
        }

        public static void DoFisherYatesAlternativeShuffle(this object[] objects)
        {
            for (int i = 0; i < objects.Length - 2; i++)
            {
                // If I were to keep building the program out, I would put the argument here as its own variable
                int j = GetRandomNumberBetweenZeroAndI((objects.Length - i) - 1);
                objects.SwapValuesAtIndices(i, i + j);
            }
        }

        private static int GetRandomNumberBetweenZeroAndI(int i)
        {
            return randomNumber.Next(i + 1);
        }
    }

    public static class Swapper
    {
        // Extracting this method to a new extension class allows us to use this method in any new classes we may create
        public static void SwapValuesAtIndices(this object[] objects, int i, int j)
        {
            object temp = objects[i];
            objects[i] = objects[j];
            objects[j] = temp;
        }
    }
}
