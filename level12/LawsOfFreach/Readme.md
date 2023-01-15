# The Laws of Freach

The town of Freach recently had an awful looping disaster. The lead investigator found that it was a faulty `++` operator in an old `for` loop, but the town council has chosen to ban all loops but the `foreach` loop. Yet Freach uses code with a `for` loop to compute the minimum and the average value in an `int array`. They have hired you to rework their existing `for`-based code to use `foreach` loops instead.

## Objectives

- Start with the code below.
- Modify the code to use `foreach` loops instead of `for` loops.

### Original code

    int[] array = new int[] {4, 51, -7, 13, -99, 15, -8, 45, 90};
    var   currentSmallest = int.MaxValue; // start higher than anything in the array
    for (var index = 0; index < array.Length; index++)
    {
        if (array[index] < currentSmallest)
        {
            currentSmallest = array[index];
        }
    }

    Console.WriteLine(currentSmallest);
