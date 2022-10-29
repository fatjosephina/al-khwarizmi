using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AssignmentIII
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string textFilePath = Path.Combine(currentDirectory, "Countries.txt");

            #region ARRAY

            // Arrays are ordered and take up less memory but are fixed size and take O(n) time for insertion and deletion
            // Arrays are best used for data which will not be altered or accessed often
            // This code reads all lines from a text file with countries and adds them to an array

            string[] countriesArray = File.ReadAllLines(textFilePath);

            // Uncomment the following line to print all of the countries in the array
            //foreach (string country in countriesArray) { Console.WriteLine(country); }

            #endregion

            #region MAP (HASHTABLE)

            // Maps such as the hash table take up more memory and are unordered but take O(1) time for operations such as insertion and deletion
            // Maps are best used for data that will be altered or accessed often
            // This code skips to the desired line in a text file with countries, creates a key for a hash table, and adds the country as the value in the hash table

            Hashtable countriesHashtable = new Hashtable();
            for (int i = 1; i <= File.ReadLines(textFilePath).Count(); i++)
            {
                countriesHashtable.Add(i, File.ReadLines(textFilePath).Skip(i - 1).Take(1).First());

                // Uncomment the following line to print all of the countries in the hashtable as they are created
                //Console.WriteLine(countriesHashtable[i]);
            }

            // Uncomment the following two lines to print all of the countries in the hashtable as well as their keys
            //ICollection keys = countriesHashtable.Keys;
            //foreach (int k in keys) { Console.WriteLine(k + ": " + countriesHashtable[k]); }

            #endregion

            #region STACK

            // Stacks are useful when you want to access data that was last stored in the stack
            // The choice between using a stack and a queue depends on the order that you want to access the data
            // This code skips to the desired line in a text file with countries and adds it to the stack

            Stack<string> countriesStack = new Stack<string>();
            for (int j = 1; j <= File.ReadLines(textFilePath).Count(); j++)
            {
                countriesStack.Push(File.ReadLines(textFilePath).Skip(j - 1).Take(1).First());
            }

            // Uncomment the following line to print all of the countries in the stack
            //foreach (var country in countriesStack) { Console.WriteLine(country); }

            #endregion

            #region QUEUE

            // Queues are useful when you want to access data in the order that it was stored in the queue
            // The choice between using a queue and a stack depends on the order that you want to access the data
            // This code skips to the desired line in a text file with countries and adds it to the queue

            Queue<string> countriesQueue = new Queue<string>();
            for (int l = 1; l <= File.ReadLines(textFilePath).Count(); l++)
            {
                countriesQueue.Enqueue(File.ReadLines(textFilePath).Skip(l - 1).Take(1).First());
            }

            // Uncomment the following line to print all of the countries in the queue
            //foreach (var country in countriesQueue) { Console.WriteLine(country); }

            #endregion

        }
    }
}
