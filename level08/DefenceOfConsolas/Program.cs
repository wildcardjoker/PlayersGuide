/*
 * The defence of Consolas
 *
 * The Uncoded One has begun an assault on the city of Consolas; the situation is dire. From a moving airship called the Manticore,
 * massive fireballs capable of destroying city blocks are being catapulted into the city.
 *
 * The city is arranged in blocks, numbered like a chessboard.
 *
 * The city's only defence is a movable magical barrier, operated by a squad of four that can protect a single city block by
 * putting themselves in each of the target's four adjacent blocks, as shown below:
 *
 * 8
 * 7       *
 * 6     * X *
 * 5       *
 * 4
 * 3
 * 2
 * 1 2 3 4 5 6 7 8
 *
 * For example, to protect the city block at (Row 7, Column 5), the crew deploys themselves to (Row 6, column 4),
 * (Row 5, Column5), (Row 6, Column 6), and (Row 7, Column 5).
 *
 * The good news is that if we can compute the deployment locations fast enough, the crew can be deployed around the target in time
 * to prevent catastrophic damage to the city for as long as the siege lasts. The City of Consolas needs a program to tell the
 * squad where to deploy, given the anticipated target. Something like this:
 *
 * Target Row? 6
 * Target Column? 5
 * Deploy to:
 * (6,4)
 * (5,5)
 * (6,6)
 * (7,5)
 *
 * Objectives:
 *
 * Ask the user for the target row and column
 * Compute the neighbouring rows and columns of where to deploy the squad
 * Display the deployment instructions in a different colour of your choosing
 * Change the window title to be "Defence of Consolas"
 * Play a sound with Console.Beep when the results have been computed and displayed
 */

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

// Play a sound with Console.Beep when the results have been computed and displayed
Console.Beep(250, 500); // 250 Hz for half a second