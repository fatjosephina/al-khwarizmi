using System;
using System.IO;
using System.Collections.Generic;

namespace AssignmentVII
{
    class Program
    {
        static void Main(string[] args)
        {
            // We get the data from a text file, put it in an array, and sort it
            string currentDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string textFilePath = Path.Combine(currentDirectory, "scores.txt");
            string[] stringScores = File.ReadAllLines(textFilePath);
            int[] scores = Array.ConvertAll(stringScores, int.Parse);
            int[] sortedScores = Quicksort(scores, 0, scores.Length - 1);

            // We create a tree to which we will add the data
            DictionaryNodeRoot tree = new DictionaryNodeRoot();

            // Using the string type allows numbers with multiple digits to be stored in branches of the tree
            foreach (int score in sortedScores)
            {
                tree.AddNumber(score.ToString());
            }

            // Then we can search for numbers in the tree
            Console.WriteLine(tree.ContainsNumber("78"));
            Console.WriteLine(tree.ContainsNumber("100"));

        }

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

        // The dictionary node root adds numbers to the tree by dividing them up into characters
        class DictionaryNodeRoot
        {
            DictionaryNode root = new DictionaryNode();

            public void AddNumber(string value)
            {
                DictionaryNode current = this.root;
                for (int i = 0; i < value.Length; i++)
                {
                    current = current.Add(value[i]);
                }
                // We can set the current number
                current.SetNumber(value);
            }

            public string ContainsNumber(string value)
            {
                bool isNumberPresent;
                // This method allows us to enter a string and then see if the characters are contained in the tree in order
                DictionaryNode current = this.root;
                for (int i = 0; i < value.Length; i++)
                {
                    current = current.Get(value[i]);
                    if (current == null)
                    {
                        isNumberPresent = false;
                        return FormulateConclusion(isNumberPresent, value);
                    }
                }
                isNumberPresent = current != null && current.GetNumber() != null;
                return FormulateConclusion(isNumberPresent, value);
            }

            // This method formulates the final sentence
            public string FormulateConclusion(bool value, string number)
            {
                string trueOrFalse;
                if (value)
                {
                    trueOrFalse = "";
                }
                else
                {
                    trueOrFalse = "not ";
                }
                string conclusion = "The number " + number + " is " + trueOrFalse + "found in the tree.";
                return conclusion;
            }
        }

        class DictionaryNode
        {
            string number;
            Dictionary<char, DictionaryNode> node;

            // This method adds the character to the dictionary
            public DictionaryNode Add(char value)
            {
                if (this.node == null)
                {
                    this.node = new Dictionary<char, DictionaryNode>();
                }

                DictionaryNode result;
                if (this.node.TryGetValue(value, out result))
                {
                    return result;
                }

                result = new DictionaryNode();
                this.node[value] = result;
                return result;
            }

            public DictionaryNode Get(char value)
            {
                // This way we can get the individual child node
                if (this.node == null)
                {
                    return null;
                }
                DictionaryNode result;
                if (this.node.TryGetValue(value, out result))
                {
                    return result;
                }
                return null;
            }

            public void SetNumber(string num)
            {
                this.number = num;
            }

            public string GetNumber()
            {
                return this.number;
            }
        }
    }
}
