/*
 * The Prototype
 *
 * Mylara, the captain of the Guard of Consolas, has approached you with the beginnings of a plan to hunt down The Uncoded One's
 * airship. "If we're going to be able to track this thing down," she says, "we need you to make us a program that can help us home
 * in on a location." She lays out a plan for a program to help with the hunt. One user, representing the airship pilot, picks a
 * number between 0 and 100. Another user, the hunter, will then attempt to guess the number. The program will tell the hunter that
 * they guessed correctly or that the number was too high or low. The program repeats until the hunter guesses the number
 * correctly. Mylara claims, "If we can build this program, we can use what we learn to build a better version to hunt down the
 * Uncoded One's airship."
 *
 * Sample program:
 * User 1, enter a number between 0 and 100: 27
 *
 * After entering this number, the program should clear the screen and continue like this:
 * User 2, guess the number.
 * What is your next guess? 50
 * 50 is too high
 * What is your next guess? 25
 * 25 is too low
 * What is your next guess? 27
 * You guessed the number!
 *
 * Objectives:
 * Build a program that will allow a user, the pilot, to enter a number
 * If the number is above 100 or less than 0, keep asking
 * Clear the screen once the program has collected a good number
 * Ask a second user, the hunter, to guess numbers
 * Indicate whether the user guessed too high, too low, or guessed right
 * Loop until they get it right, then end the program
 */

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