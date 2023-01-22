// We'll assume a near-infinite grid. Don't try values over +/-2 billion...
// In keeping with the features taught in the book thus far, we'll use single variables for each value.
// In a real application, we'd use a tuple (x,y), or a Class.

// Change the window title to be "Defence of Consolas"

Console.Title = "Defence of Consolas";

// Ask the user for the target row and column.
// Using Console.Write(), the answer can be input on the same line (finally!)
Console.Write("Target Row?    ");
var row = Convert.ToInt32(Console.ReadLine());
Console.Write("Target column? ");
var column = Convert.ToInt32(Console.ReadLine());

// Compute the neighbouring rows and columns of where to deploy the squad
// Don't use unary operators (row++, column--) here, as that will affect the values of row and column.
var topRow      = row    + 1;
var bottomRow   = row    - 1;
var leftColumn  = column - 1;
var rightColumn = column + 1;

// Display the deployment instructions in a different colour of your choosing
Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.DarkRed;
Console.WriteLine($"({row},{leftColumn})");
Console.WriteLine($"({bottomRow},{column})");
Console.WriteLine($"({row},{rightColumn})");
Console.WriteLine($"({topRow},{column})");

// The if statement here isn't covered in the books, but I've added it here to remove the Build Warning CA1416: This call site is reachable on all platforms. 'Console.Beep(int, int)' is only supported on: 'windows'.

if (OperatingSystem.IsWindows())
{
    // Play a sound with Console.Beep when the results have been computed and displayed
    Console.Beep(250, 500); // 250 Hz for half a second
}