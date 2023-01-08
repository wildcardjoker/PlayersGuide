/*
 * The Replicator of D'To
 *
 * While searching an abandoned storage building containing strange code artifacts, you uncover the ancient Replicator of D'To. This
 * can replicate the contents of any int array into another array. But it appears broken and needs a Programmer to reforge the magic
 * that allows it to replicate once again.
 *
 * Objectives:
 * Make a program that creates an array of length 5.
 * Ask the user for five numbers and put them in the array.
 * Make a second array of length 5.
 * Use a loop to copy the values out of the original array and into the new one.
 * Display the contents of both arrays one at a time to illustrate that the Replicator of D/To works again.
 */

// While there are easier ways to copy an array, we'll do it the 'hard' way.

/* For reference, here are some ways to reference the values in an array
 array[i]       Reference the value at index i
 array[^1]      Reference the last value in the array
 array[^2]      Reference the second last value in the array
 array[0..3]    Reference the first three values in the array (0 - 2). The second index is the maximum, but not returned, index
 array[1..^1]   Reference all items in the array, except for the first and last items
 array[2..]     Reference all but the first 2 items in the array
 */

Console.Title = "The Replicator of D'To";

// Make a program that creates an array of length 5.
var userArray = new int[5];

// Ask the         user for five numbers and put them in the array.
for (var i = 0; i < userArray.Length; i++)
{
    Console.Write("Please enter a number: ");
    userArray[i] = Convert.ToInt32(Console.ReadLine());
}

// Make a second array of length 5.
var copiedArray = new int[5];

// Use a loop to copy the values out of the original array and into the new one.
for (var i = 0; i < copiedArray.Length; i++)
{
    copiedArray[i] = userArray[i];
}

// Display the contents of  both arrays one at        a time       to illustrate that the Replicator of D /To works again.
Console.WriteLine("User's Array  Copied Array");
for (var i = 0; i < userArray.Length; i++)
{
    Console.WriteLine($"{userArray[i],12}{copiedArray[i],14}");
}