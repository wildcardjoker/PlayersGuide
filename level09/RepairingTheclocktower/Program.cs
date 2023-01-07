/*
 * Repairing the Clocktower
 *
 * The recent attacks damaged the great Clocktower of Consolas. The citizens of Consolas have repaired most of it, except one piece
 * that requires the steady hand of a Programmer. It is the part that makes the clock tick and tock. Numbers flow into the clock to
 * make it go, and if the number is even, the clock's pendulum should tick to to the left; if the number is odd, the pendulum should
 * tock to the right. Only a programmer can recreate this critical clock element to make it work again.
 *
 * Objectives:
 * Take a number as input from the console
 * Display the word "Tick" if the number is even. Display the word "Tock" if the number is odd.
 * Hint: Remember that you can use the remainder operator to determine if a number is even or odd.
 */

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