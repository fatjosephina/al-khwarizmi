using System;
using System.IO;

namespace AssignmentV
{
    class Program
    {
        static float[] sortTimes = new float[6];

        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string textFilePath = Path.Combine(currentDirectory, "scores.txt");
            string[] stringScores = File.ReadAllLines(textFilePath);
            int[] scores = Array.ConvertAll(stringScores, int.Parse);
            Bubblesort(scores);
            Console.WriteLine("The bubble sort took " + sortTimes[0] + " ticks to sort the array of scores.");
            Insertionsort(scores);
            Console.WriteLine("The insertion sort took " + sortTimes[1] + " ticks to sort the array of scores.");
            Selectionsort(scores);
            Console.WriteLine("The selection sort took " + sortTimes[2] + " ticks to sort the array of scores.");
            Heapsort(scores);
            Console.WriteLine("The heap sort took " + sortTimes[3] + " ticks to sort the array of scores.");
            Quicksort(scores, 0, scores.Length - 1);
            Console.WriteLine("The quick sort took " + sortTimes[4] + " ticks to sort the array of scores.");
            Mergesort(scores, 0, scores.Length - 1);
            Console.WriteLine("The merge sort took " + sortTimes[5] + " ticks to sort the array of scores.");

            string fastestAlgorithm = CalculateFastest();
            Console.WriteLine("In summary, the " + fastestAlgorithm + " was the fastest.");

        }

        #region BUBBLESORT

        /* Bubble Sort
         * Description: This sorting algorithm starts at the beginning of an array and swaps the first two elements if the first is greater than the second.
         *              It then does the same operation continuing through the array.
         * Best Case Runtime: O(n)
         * Worst Case Runtime: O(n^2)
         * Pseudocode: Bubblesort(Data: values[])
                       // Repeat until the array is sorted.
                       Boolean: not_sorted = True
                       While (not_sorted)
                            // Assume we won't find a pair to swap.
                            not_sorted = False
                            // Search the array for adjacent items that are out of order.
                            For i = 0 To <length of values> - 1

                                // See if items i and i - 1 are out of order.
                                If (values[i] < values[i - 1]) Then
                                    // Swap them.
                                    Data: temp = values[i]
                                    values[i] = values[i - 1]
                                    values[i - 1] = temp

                                    // The array isn't sorted after all.
                                    not_sorted = True
                                End If
                            Next i
                        End While
                        End Bubblesort  
         */
        static int[] Bubblesort(int[] array)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            bool notSorted = true;
            while (notSorted)
            {
                notSorted = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        var temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;

                        notSorted = true;
                    }
                }
            }
            //foreach (int i in array) { Console.Write(i + " ");  }
            watch.Stop();
            sortTimes[0] = watch.ElapsedTicks;
            return array;
        }
        #endregion

        #region INSERTIONSORT

        /* Insertion Sort
         * Description: This sorting algorithm builds the final sorted set one item at a time.
         *              It is efficient on small data sets but is much less efficient on large sets.
         * Best Case Runtime: O(n)
         * Worst Case Runtime: O(n^2)
         * Pseudocode: Insertionsort(Data: values[])
                        For i = 0 To <length of values> - 1
                            // Move item i into position
                            //in the sorted part of the array
                            < Find  the first index j where
                            j < i and values[j] > values[i].>
                            <Move the item into position j.>
                        Next i
                       End Insertionsort 
         */
        static int[] Insertionsort(int[] array)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        var temp = array[j - 1];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //foreach (int i in array) { Console.Write(i + " ");  }
            watch.Stop();
            sortTimes[1] = watch.ElapsedTicks;
            return array;
        }
        #endregion

        #region SELECTIONSORT

        /* Selection Sort
         * Description: This sorting algorithm finds the position of the smallest element in the array and swaps it with the first element in the array.
         *              It is very inefficient on large data sets and generally less efficient than other sorting algorithms.
         * Best Case Runtime: O(n)
         * Worst Case Runtime: O(n^2)
         * Pseudocode: Selectionsort(Data: values[])
                        For i = 0 To <length of values> - 1
                            // Find the item that belongs in position i.
                            <Find the smallest item with index j >= i.>
                            <Swap values[i] and values[j].>
                        Next i
                       End Selectionsort  
         */
        static int[] Selectionsort(int[] array)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int temp, smallest;
            for (int i = 0; i < array.Length - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = array[smallest];
                array[smallest] = array[i];
                array[i] = temp;
            }
            //foreach (int i in array) { Console.Write(i + " ");  }
            watch.Stop();
            sortTimes[2] = watch.ElapsedTicks;
            return array;
        }

        #endregion

        #region HEAPSORT

        /* Heap Sort
         * Description: This sorting algorithm divides the input into sorted and unsorted areas.
         *              It uses a heap based data structure which allows the largest element in each step to be found more quickly.
         * Best Case Runtime: O(n log n)
         * Worst Case Runtime: O(n log n)
         * Pseudocode: Heapsort(Data: values)
                        <Turn the array into a heap.>
                        For i = <length of values> - 1 To 0 Step -1
                            // Swap the root item and the last item.
                            Data: temp = values[0]
                            values[0] = values[i]
                            values[i] = temp
 
                            <Consider the item in position i to be removed from the heap,
                            so the heap now holds i - 1 items. Push the new root value
                            down into the heap to restore the heap property.>
                        Next i
                       End Heapsort  
         */
        static int[] Heapsort(int[] array)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int n = array.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                addToHeap(array, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                addToHeap(array, i, 0);
            }
            //foreach (int i in array) { Console.Write(i + " ");  }
            watch.Stop();
            sortTimes[3] = watch.ElapsedTicks;
            return array;
        }

        static void addToHeap(int[] array, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && array[l] > array[largest])
                largest = l;

            if (r < n && array[r] > array[largest])
                largest = r;

            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                addToHeap(array, n, largest);
            }
        }
        #endregion

        #region QUICKSORT

        /* Quick Sort
         * Description: This sorting algorithm uses a divide-and-conquer strategy by choosing an element in the array to act as a pivot.
         *              The pivot separates the array into two parts, and each element in the subsections is compared to the pivot for sorting.
         * Best Case Runtime: O(n log n)
         * Worst Case Runtime: O(n^2)
         * Pseudocode: Quicksort(A, lo, hi) is
                            if lo < hi then
                                p := pivot(A, lo, hi)
                                left, right := partition(A, p, lo, hi)  // note: multiple return values
                            quicksort(A, lo, left - 1)
                            quicksort(A, right + 1, hi) 
         */
        static int[] Quicksort(int[] array, int leftIndex, int rightIndex)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
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
            //foreach (int i in array) { Console.Write(i + " ");  }
            watch.Stop();
            sortTimes[4] = watch.ElapsedTicks;
            return array;
        }

        #endregion

        #region MERGESORT

        /* Merge Sort
         * Description: This sorting algorithm also uses a divide and conquer strategy.
         *              Instead of picking a dividing item and splitting the items into two groups holding items that are larger and smaller than the dividing item,
         *              mergesort splits the items into two halves holding an equal number of items. It then recursively calls itself to sort the two halves.
         * Best Case Runtime: O(n log n)
         * Worst Case Runtime: O(n log n)
         * Pseudocode: Mergesort(Data: values[], Data: scratch[], Integer: start, Integer: end)
                           // If the array contains only one item, it is already sorted.

                            If (start == end) Then Return
 
                            // Break the array into left and right halves.
                            Integer: midpoint = (start + end) / 2
 
                            // Call Mergesort to sort the two halves.
                            Mergesort(values, scratch, start, midpoint)
                            Mergesort(values, scratch, midpoint + 1, end)
 
                            // Merge the two sorted halves.
                            Integer: left_index = start
                            Integer: right_index = midpoint + 1
                            Integer: scratch_index = left_index
                            While ((left_index <= midpoint) And (right_index <= end))
                                If (values[left_index] <= values[right_index]) Then
                                    scratch[scratch_index] = values[left_index]
                                    left_index = left_index + 1
                                Else
                                    scratch[scratch_index] = values[right_index]
                                    right_index = right_index + 1
                                End If
                                scratch_index = scratch_index + 1    End While
 
                                // Finish copying whichever half is not empty.
                                For i = left_index To midpoint
                                    scratch[scratch_index] = values[i]
                                    scratch_index = scratch_index + 1
                                Next i
                                For i = right_index To end
                                    scratch[scratch_index] = values[i]
                                    scratch_index = scratch_index + 1
                                Next i
                            // Copy the values back into the original values array.
                            For i = start To end
                                values[i] = scratch[i]
                            Next i
                   End Mergesort
         */
        static int[] Mergesort(int[] array, int leftIndex, int rightIndex)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (leftIndex < rightIndex)
            {
                int middle = leftIndex + (rightIndex - leftIndex) / 2;
                Mergesort(array, leftIndex, middle);
                Mergesort(array, middle + 1, rightIndex);
                Merge(array, leftIndex, middle, rightIndex);
            }
            //foreach (int i in array) { Console.Write(i + " ");  }
            watch.Stop();
            sortTimes[5] = watch.ElapsedTicks;
            return array;
        }


        static void Merge(int[] array, int leftIndex, int middleIndex, int rightIndex)
        {
            var leftArrayLength = middleIndex - leftIndex + 1;
            var rightArrayLength = rightIndex - middleIndex;
            var leftTempArray = new int[leftArrayLength];
            var rightTempArray = new int[rightArrayLength];
            int i, j;
            for (i = 0; i < leftArrayLength; ++i)
                leftTempArray[i] = array[leftIndex + i];
            for (j = 0; j < rightArrayLength; ++j)
                rightTempArray[j] = array[middleIndex + 1 + j];
            i = 0;
            j = 0;
            int k = leftIndex;
            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i] <= rightTempArray[j])
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {
                    array[k++] = rightTempArray[j++];
                }
            }
            while (i < leftArrayLength)
            {
                array[k++] = leftTempArray[i++];
            }
            while (j < rightArrayLength)
            {
                array[k++] = rightTempArray[j++];
            }
        }

        #endregion

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
                fastestAlgorithm = "bubble sort";
            }
            else if (fastestAlgorithm == 1.ToString())
            {
                fastestAlgorithm = "insertion sort";
            }
            else if (fastestAlgorithm == 2.ToString())
            {
                fastestAlgorithm = "selection sort";
            }
            else if (fastestAlgorithm == 3.ToString())
            {
                fastestAlgorithm = "heap sort";
            }
            else if (fastestAlgorithm == 4.ToString())
            {
                fastestAlgorithm = "quick sort";
            }
            else if (fastestAlgorithm == 5.ToString())
            {
                fastestAlgorithm = "merge sort";
            }
            return fastestAlgorithm;
        }
    }
}
