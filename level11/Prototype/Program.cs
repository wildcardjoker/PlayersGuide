Console.Title = "The Prototype";

// Set an invalid number to trigger the loop
var targetNumber = 1;

// Set a variable for the hunter's guess
var currentGuess = -1;

do
{
    Console.Write("Pilot, enter a number between 0 and 100: ");
    targetNumber = Convert.ToInt32(Console.ReadLine());
}
while (targetNumber < 0 || targetNumber > 100);

// We have a number, now it's time for the hunter to guess.
// Clear the console so that the hunter can't see the target number
Console.Clear();

Console.WriteLine("Hunter, you must guess a number between 0 and 100");
while (currentGuess != targetNumber)
{
    Console.Write("Hunter, what is your next guess? ");
    currentGuess = Convert.ToInt32(Console.ReadLine());

    // If the first guess is correct, break out of the loop
    if (currentGuess == targetNumber)
    {
        break;
    }

    // Tell the hunter whether their guess was too high or too low
    var range = currentGuess < targetNumber ? "low" : "high";
    Console.WriteLine($"{currentGuess} is too {range}");
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("You guessed the number!");