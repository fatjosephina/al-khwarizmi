# Assignment I: Code Examples
This is a Readme file for [>Assignment I<](https://github.com/fatjosephina/al-khwarizmi/blob/main/AssignmentI/AssignmentI/Program.cs).

This program demonstrates an understanding of Big O notation in the form of constant time (O(1)), linear time (O(n)), and quadratic time (O(n^2)). It does this by using different variations on writing "Hello."

* Starting at line 15, O(1), or constant time, is demonstrated. It simply writes "Hello!" regardless of the value of _n_. Therefore, this method is in constant time, because regardless of the value of _n_, it will always take the same amount of time to execute.

* Starting at line 22, O(n), also called linear time, is demonstrated. It uses a for loop to say hello to _n_ amount of people. This means that it is in linear time because the number of times that the loop runs is directly proportional to _n_.


* Finally, starting at line 32, O(n^2), or quadratic time, is demonstrated. The method uses nested for loops, which each run _n_ amount of times. In this hypothetical scenario, a teacher is saying hello to each of the classes that they teach. Each class has _n_ students and the teacher has _n_ classes. Therefore, the teacher says hello to each class and each member of the class says hello back to the teacher. Because the amount of times that the loops run is equal to n^2 (n * n), this method is in quadratic time.
