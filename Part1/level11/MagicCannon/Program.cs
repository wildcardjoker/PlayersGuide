// Ah, good old FizzBuzz :)
// Let's start by setting the minimum and maximum values.

var min = 1;
var max = 100;

// Then, set up the fire and electric crank turns
// Again, these could all be constants, but they haven't yet been introduced
var fireTurns     = 3;
var electricTurns = 5;
var combinedTurns = fireTurns * electricTurns;

// Now, set the foreground colours.
var fireColour     = ConsoleColor.Red;
var combinedColour = ConsoleColor.Blue;
var electricColour = ConsoleColor.Yellow;

Console.Title = "The Magic Cannon";
for (var i = min; i <= max; i++)
{
    Console.ResetColor();
    Console.Write($"{i,3}: "); // Pad out the number so that it aligns in the console

    // Create a variable for storing the kind of blast we can expect.
    // We could use an enum for this, but we'll stick with a standard string for now.
    string blastType;
    if (i % combinedTurns == 0)
    {
        Console.ForegroundColor = combinedColour;
        blastType               = "Electric Fire";
    }
    else if (i % electricTurns == 0)
    {
        Console.ForegroundColor = electricColour;
        blastType               = "Electric";
    }
    else if (i % fireTurns == 0)
    {
        Console.ForegroundColor = fireColour;
        blastType               = "Fire";
    }
    else
    {
        blastType = "Normal";
    }

    // Output the blast type to the console.
    Console.WriteLine(blastType);
}