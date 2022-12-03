# Assignment III: Data Structures
This is a Readme file for [>Assignment III<](https://github.com/fatjosephina/al-khwarizmi/blob/main/AssignmentIII/AssignmentIII/Program.cs).

This program demonstrates the creation of an array, a map (in the form of a hash table), a stack, and a queue. Each of these data structures takes information from a text file, called Countries.txt, and adds it to their data. The text file contains a list of all the countries recognized by the United Nations. Each section of the code also contains some lines which can be uncommented to print the data in each structure.

* The region showing how the information can be stored in an array starts at line 16. This is pretty simple code in C# because arrays will automatically take each line from the text document and store it in the array if they are equated to ```File.ReadAllLines()```.
  * Arrays are ordered and take up less memory but are fixed size and take O(n) time for insertion and deletion.
  * Arrays are best used for data which will not be altered or accessed often.

* The region showing how the information can be stored in a map starts at line 29. I used a hash table in C# because it is a type of map. The simplest way to do this in C# is to add all of the lines of the text document to an array, and then transfer the data from the array to a hash table. However, we do not want this because it involves creating an array first. Instead, I used a for loop which goes through each line in the text document and manually adds them to the hash table. This can be done by skipping to the desired line and adding it. The for loop keeps track of which line is the desired line.
  * Maps such as the hash table take up more memory and are unordered but take O(1) time for operations such as insertion and deletion.
  * Maps are best used for data that will be altered or accessed often.

* The region showing how the information can be stored in a stack starts at line 50. Adding information to the stack also involves recursively going through each line in the text document and pushing it in string form to the stack. It is mostly similar to the way that I did the hash table.
  * Stacks are useful when you want to access data that was last stored in the stack.
  * The choice between using a stack and a queue depends on the order that you want to access the data.

* The region showing how the information can be stored in a queue starts at line 67. Adding information to the queue also involves recursively going through each line in the text document and enqueuing it. It is very similar to adding information to the stack.
  * Queues are useful when you want to access data in the order that it was stored in the queue.
  * The choice between using a queue and a stack depends on the order that you want to access the data.
