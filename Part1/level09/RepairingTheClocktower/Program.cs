Console.Title = "Repairing the Clocktower";
Console.WriteLine("Numbers flow into the clock");
Console.WriteLine("The clock will -tick- if the number is even, and -tock- if the number is odd.");
Console.Write("\nWhat is the number? ");
var clockNumber = Convert.ToInt32(Console.ReadLine());

// Tick or tock
var isEven = clockNumber % 2 == 0;

// Let's kick it up a notch, using the lessons from the last level
// Normally, I'd set these using a ternary operator, but the book hasn't covered them yet.
ConsoleColor foreColor;
int          frequency;
if (isEven)
{
    foreColor = ConsoleColor.Cyan;
    frequency = 600;
}
else
{
    foreColor = ConsoleColor.Magenta;
    frequency = 300;
}

Console.ForegroundColor = foreColor;

// Again, we'd normally use a ternary operator.
if (isEven)
{
    Console.WriteLine("Tick");
}
else
{
    Console.WriteLine("Tock");
}

// "Bing!" for tick, "Bong!" for tock
Console.Beep(frequency, 500);