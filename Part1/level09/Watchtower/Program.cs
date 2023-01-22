Console.Title = "The Watchtower";
Console.WriteLine("Please enter the coordinates of the enemy.");
Console.WriteLine();
Console.Write("Please enter the x coordinates: ");
var x = Convert.ToInt32(Console.ReadLine());
Console.Write("Please enter the y coordinates: ");
var y = Convert.ToInt32(Console.ReadLine());

// Set a variable for the direction
string direction;

// Calculate direction
if (x == 0 && y == 0)
{
    direction = "here";
}
else if (x == 0)
{
    // y cannot be 0, so we're looking at N or S
    direction = y > 0 ? "north" : "south";
}
else if (x < 0)
{
    if (y == 0)
    {
        direction = "west";
    }
    else
    {
        // Direction can only be SW or NW. Use the ternary operator to decide.
        direction = y < 0 ? "southwest" : "northwest";
    }
}
else
{
    // These statements could be condensed into a single statement, but we'll stick with the simple example.
    // For reference, this line is the same as the if block below:
    // direction = y == 0 ? "east" : y < 0 ? "southeast" : "northeast";

    if (y == 0)
    {
        direction = "east";
    }
    else
    {
        // x > 0 and y < 0 or y > 0
        direction = y < 0 ? "southeast" : "northeast";
    }
}

if (direction != "here")
{
    direction = $"to the {direction}";
}

// Let's get fancy with the terminal again...
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"The enemy is {direction}!");