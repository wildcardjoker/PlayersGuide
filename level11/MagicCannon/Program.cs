/* The Magic Cannon
 *
 * Skorin, a member of Consolas's wall guard, has constructed a magic cannon that draws power from two gems: a fire gem and an
 * electric gem. Every third turn of a crank, the fire gem activates, and the cannon produces a fire blast. The electric gem
 * activates every fifth turn of the crank, and the cannon makes an electric blast. When the two line up, it generates a potent
 * combined blast. Skorin would like your help to produce a program that can warn the crew about which turns of the crank will
 * produce the different blasts before they do it.
 *
 * A partial output of the desired program looks like this:
 * 1: Normal
 * 2: Normal
 * 3: Fire
 * 4: Normal
 * 5: Electric
 * 6: Fire
 * 7: Normal
 * ...
 *
 * Objectives:
 * Write a program that will loop through the values between 1 and 100 and display what kind of blast the crew should expect. (The % operator may be of use).
 * Change the colour of the output based on the type of blast. For example, red for Fire, yellow for Electric, and Blue for Electric and Fire.
*/

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