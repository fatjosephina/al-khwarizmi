# Assignment VI: Searching
This is a Readme file for [>Assignment VI<](https://github.com/fatjosephina/al-khwarizmi/blob/main/AssignmentVI/AssignmentVI/Program.cs).

This program demonstrates three different searching algorithms which are used to search the same array of numbers taken from a text file for a pseudorandom number. It then compares how well each algorithm performs time-wise and displays a summary. The searching algorithms included are linear search, binary search, and interpolation search. The code is divided into regions, which each include the implementation of a single algorithm along with comments displaying its name, description, best case runtime, worst case runtime, and the algorithm in pseudocode form. For binary search and interpolation search which require sorted arrays, quick sort is used to sort the array.

* The region demonstrating linear search starts at line 48. This searching algorithm sequentially checks each element of a data set. It is generally not very efficient.
  * **Best Case Runtime:** O(1)
  * **Worst Case Runtime:** O(n)

* The region demonstrating binary search starts at line 67. This searching algorithm requires a sorted data set. It compares the value in the middle of the data set to the value being searched for. If the values are equal, the target has been found. If the values are not equal, the algorithm determines which half of the data set will contain the target. The search procedure is repeated recursively with the remaining half of the data set that will contain the target value.
  * **Best Case Runtime** O(1)
  * **Worst Case Runtime:** O(log n)

* The region demonstrating interpolation search starts at line 116. This searching algorithm requires a sorted data set. Binary search always chooses the middle of the data set before discarding one half or the other. Interpolation search uses keys. For interpolation search to work efficiently, data must be uniformly distributed (in addition to being sorted).
  * **Best Case Runtime:** O(1)
  * **Worst Case Runtime:** O(n)
