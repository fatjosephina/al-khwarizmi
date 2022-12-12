# Assignment VII: Trees
This is a Readme file for [>Assignment VII<](https://github.com/fatjosephina/al-khwarizmi/blob/main/AssignmentVII/AssignmentVII/Program.cs).

This program demonstrates the creation of a tree, as well as searching in a tree. It does so using C#'s Dictionary class. The program reads numbers from a text file and adds them to a tree. It then searches the trees for some numbers and prints the results in a summary.

* At line 9, the Main() method begins. This method takes in the data from the text file and puts them in an array which is then sorted. It then adds the sorted scores to a tree which is created. Finally, it tests out searching through the tree.
* The DictionaryNodeRoot class which begins at line 68 allows us to create the root node for the tree. It also contains the logic necessary for searching the tree with the ContainsNumber() method. It loops through the value given and checks if it is present in the tree. It also uses the GetNumber() method of the DictionaryNode class to check if the value is contained in the tree.
* The DictionaryNode class begins at line 118. This contains the logic for adding a node to the tree as well as getting and setting a number. The symbiosis between the logic of this class and the logic of the DictionaryNodeRoot class is what makes all of the functions of the tree possible.
