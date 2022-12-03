# Assignment II: Fisher-Yates Shuffle
This is a Readme file for [>Assignment II<](https://github.com/fatjosephina/al-khwarizmi/blob/main/AssignmentII/AssignmentII/Program.cs).

This program demonstrates a the Fisher-Yates shuffle algorithm in two different ways. Both methods use extension classes and the Random class to shuffle an array of letters. All classes are included in the same .cs file for easier reading.

* The first method starts at line 37. This method uses a decrementing for loop that runs through every letter in the letter array. It gets a random number between zero and the _i_ variable initialized in the loop, which starts equal to the length of the letter array minus one (```objects.Length - 1```). It then swaps the letters in the array that are indiced at _i_ and the random number. This is the Fisher-Yates shuffle because it is going through the array and swapping elements until every value in the array has been swapped at least once.

* The alternative method starts at line 48. This method uses an incrementing for loop which runs while it is smaller than the length of the letter array minus two (```objects.Length - 2```). This time, the random number is between zero and the length of the object array minus _i_, minus one (```(objects.Length - i) - 1```). It then swaps _i_ with _i_ plus the new number. This accomplishes the same result of the Fisher-Yates shuffle, but starts at the beginning of the array rather than the end.
