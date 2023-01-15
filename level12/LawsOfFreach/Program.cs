int[] array           = {4, 51, -7, 13, -99, 15, -8, 45, 90};
var   currentSmallest = int.MaxValue; // start higher than anything in the array

// There are many ways you can find the smallest number:
// - sort the array, then return the first value
// - use LINQ's Min() function
// We're following along with the book, so stick with foreach
foreach (var i in array)
{
    if (i < currentSmallest)
    {
        currentSmallest = i;
    }
}

Console.WriteLine(currentSmallest);