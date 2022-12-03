# Assignment V: Sorting
This is a Readme file for [>Assignment V<](https://github.com/fatjosephina/al-khwarizmi/blob/main/AssignmentV/AssignmentV/Program.cs).

This program demonstrates six different sorting algorithms which are used to sort the same array of numbers taken from a text file. It then compares how well each algorithm performs time-wise and displays a summary. The sorting algorithms included are bubble sort, insertion sort, selection sort, heap sort, quick sort, and merge sort. The code is divided into regions, which each include the implementation of a single algorithm along with comments displaying its name, description, best case runtime, worst case runtime, and the algorithm in pseudocode form.

* The region demonstrating bubble sort starts at line 34. This sorting algorithm starts at the beginning of an array and swaps the first two elements if the first is greater than the second. It then does the same operation continuing through the array.
  * **Best Case Runtime:** O(n)
  * **Worst Case Runtime:** O(n^2)

* The region demonstrating insertion sort starts at line 90. This sorting algorithm builds the final sorted set one item at a time. It is efficient on small data sets but is much less efficient on large sets.
  * **Best Case Runtime** O(n)
  * **Worst Case Runtime:** O(n^2)

* The region demonstrating selection sort starts at line 133. This sorting algorithm finds the position of the smallest element in the array and swaps it with the first element in the array. It is very inefficient on large data sets and generally less efficient than other sorting algorithms.
  * **Best Case Runtime:** O(n)
  * **Worst Case Runtime:** O(n^2)

* The region demonstrating heap sort starts at line 174. This sorting algorithm divides the input into sorted and unsorted areas. It uses a heap based data structure which allows the largest element in each step to be found more quickly.
  * **Best Case Runtime:** O(n log n)
  * **Worst Case Runtime:** O(n log n)

* The region demonstrating quick sort starts at line 239. This sorting algorithm uses a divide-and-conquer strategy by choosing an element in the array to act as a pivot. The pivot separates the array into two parts, and each element in the subsections is compared to the pivot for sorting.
  * **Best Case Runtime:** O(n log n)
  * **Worst Case Runtime:** O(n^2)

* The region demonstrating merge sort starts at line 292. This sorting algorithm also uses a divide-and-conquer strategy. Instead of picking a dividing item and splitting the items into two groups holding items that are larger and smaller than the dividing item, mergesort splits the items into two halves holding an equal number of items. It then recursively calls itself to sort the two halves.
  * **Best Case Runtime:** O(n log n)
  * **Worst Case Runtime:** O(n log n)
