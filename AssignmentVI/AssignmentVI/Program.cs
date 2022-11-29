using System;
using System.IO;

namespace AssignmentVI
{
    class Program
    {
        static float[] sortTimes = new float[3];

        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string textFilePath = Path.Combine(currentDirectory, "scores.txt");
            string[] stringScores = File.ReadAllLines(textFilePath);
            int[] scores = Array.ConvertAll(stringScores, int.Parse);

            Random randomGenerator = new Random();
            int randomNumber = randomGenerator.Next(0, 101);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            LinearSearch(scores, randomNumber);
            watch.Stop();
            sortTimes[0] = watch.ElapsedTicks;

            Console.WriteLine("The linear search took " + sortTimes[0] + " ticks to sort the array of scores.");

            int[] sortedScores = Quicksort(scores, 0, scores.Length - 1);

            watch = System.Diagnostics.Stopwatch.StartNew();
            BinarySearch(sortedScores, randomNumber);
            watch.Stop();
            sortTimes[1] = watch.ElapsedTicks;

            Console.WriteLine("The binary search took " + sortTimes[1] + " ticks to sort the array of scores.");

            watch = System.Diagnostics.Stopwatch.StartNew();
            InterpolationSearch(sortedScores, randomNumber);
            watch.Stop();
            sortTimes[2] = watch.ElapsedTicks;

            Console.WriteLine("The interpolation search took " + sortTimes[2] + " ticks to sort the array of scores.");

            string fastestAlgorithm = CalculateFastest();
            Console.WriteLine("In summary, the " + fastestAlgorithm);

        }

        #region LINEARSEARCH

        /* Linear Search
         * Description: This searching algorithm sequentially checks each element of a data set. It is generally not very efficient.
         * Best Case Runtime: O(1)
         * Worst Case Runtime: O(n)
         * Pseudocode: function linear_search Begin
                        1) Set i = 0
                        2) If Li = T, go to line 4
                        3) Increase i by 1 and go to line 2
                        4) If i < n then return i
                       End
         */
        static int LinearSearch(int[] array, int value)
        {
            return Array.IndexOf(array, value);
        }
        #endregion

        #region BINARYSEARCH

        /* Binary Search
         * Description: This searching algorithm requires a sorted data set. It compares the value in the middle of the data set to the value being searched for.
         *              If the values are equal, the target has been found.
         *              If the values are not equal, the algorithm determines which half of the data set will contain the target. 
         *              The search procedure is repeated recursively with the remaining half of the data set that will contain the target value.
         * Best Case Runtime: O(1)
         * Worst Case Runtime: O(log n)
         * Pseudocode: function binary_search(A, n, T) is
                                    L := 0
                                    R := n − 1
                                    while L ≤ R do
                                            m := floor((L + R) / 2)
                                                if A[m] < T then
                                                     L := m + 1
                                                else if A[m] > T then
                                                     R := m − 1
                                                else:
                                                    return m
                                                return unsuccessful
         */
        static int BinarySearch(int[] array, int value)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int lowerBound = 0;
            int upperBound = array.Length;
            while (lowerBound <= upperBound)
            {
                int midPoint = (lowerBound + upperBound) / 2;
                if (array[midPoint] > value)
                {
                    upperBound = midPoint - 1;
                }
                else if (array[midPoint] < value)
                {
                    lowerBound = midPoint + 1;
                }
                else
                {
                    return midPoint;
                }
            }
            watch.Stop();
            sortTimes[1] = watch.ElapsedTicks;
            return -1;
        }
        #endregion

        #region INTERPOLATIONSEARCH

        /* Interpolation Search
         * Description: This searching algorithm requires a sorted data set. Binary search always chooses the middle of the data set
         *              before discarding one half or the other. Interpolation search uses keys. For interpolation search to work efficiently,
         *              data must be uniformly distributed (in addition to being sorted).
         * Best Case Runtime: O(1)
         * Worst Case Runtime: O(n)
         * Pseudocode: function interpolation_search Begin
                        Calculate the value of “pos” using the probe position formula (which is shown above).
                        If there is a match, return the index of the item, and exit.
                        If the item is less than the arr[pos], calculate the probe position of the left sub-array.
                        Otherwise calculate the same in the right sub-array.
                        Repeat until a match is found or the sub-array reduces to zero.
                       End
         */
        static int InterpolationSearch(int[] array, int value)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int lowerBound = 0;
            int upperBound = array.Length - 1;
            int position;

            while (lowerBound <= upperBound && value >= array[lowerBound] && value <= array[upperBound])
            {
                position = lowerBound + (((upperBound - lowerBound) / (array[upperBound] - array[lowerBound])) * (value - array[lowerBound]));
                if (array[position] == value)
                {
                    return position;
                }

                if (array[position] < value)
                {
                    lowerBound = position + 1;
                }

                if (array[position] > value)
                {
                    upperBound = position - 1;
                }
            }
            watch.Stop();
            sortTimes[2] = watch.ElapsedTicks;
            return -1;
        }

        #endregion
       
        // We'll use quick sort to sort the array
        static int[] Quicksort(int[] array, int leftIndex, int rightIndex)
        {
            var k = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (k <= j)
            {
                while (array[k] < pivot)
                {
                    k++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }
                if (k <= j)
                {
                    int temp = array[k];
                    array[k] = array[j];
                    array[j] = temp;
                    k++;
                    j--;
                }
            }

            if (leftIndex < j)
                Quicksort(array, leftIndex, j);
            if (k < rightIndex)
                Quicksort(array, k, rightIndex);
            return array;
        }

        static string CalculateFastest()
        {
            string fastestAlgorithm = " ";
            int[] sortedTimes = Quicksort(Array.ConvertAll(sortTimes, Convert.ToInt32), 0, sortTimes.Length - 1);
            foreach (float f in sortTimes)
            {
                if (f == sortedTimes[0])
                    fastestAlgorithm = Array.IndexOf(sortTimes, f).ToString();
            }
            if (fastestAlgorithm == 0.ToString())
            {
                fastestAlgorithm = "linear search was the fastest. Linear search works best for small data sets.";
            }
            else if (fastestAlgorithm == 1.ToString())
            {
                fastestAlgorithm = "binary search was the fastest. Binary search works best in most cases.";
            }
            else if (fastestAlgorithm == 2.ToString())
            {
                fastestAlgorithm = "interpolation search was the fastest. Interpolation search works best for data that is uniformly distributed in the array.";
            }
            return fastestAlgorithm;
        }
    }
}
