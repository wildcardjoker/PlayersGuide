Console.Title = "Hunt the Manticore";

// Establish the game's starting state: the Manticore begins with 10 health points and the city with 15. The game starts at round 1.
var maxManticoreHealth = 10;
var minManticoreHealth = 0;
var maxCityHealth      = 15;
var minCityHealth      = 0;
var currentRound       = 1;
var manticoreHealth    = maxManticoreHealth;
var cityHealth         = maxCityHealth;

// Ask the first player to choose the Manticore's distance from the city (0 to 100). Clear the screen afterward.
var manticoreLocation = AskForNumberInRange("Player 1, how far away from the city to you want to station the Manticore (0 - 100)", 0, 100);
Console.Clear();

// Methods

// Accept input from the console and convert it to an integer.
// Still no error handling
int AskForNumber(string text)
{
    Console.Write($"{text}? "); // Add a space to the end of the question
    return Convert.ToInt32(Console.ReadLine());
}

// Prompt user for a number within the specified range until a valid input is provided
int AskForNumberInRange(string text, int min, int max)
{
    int number;
    do
    {
        number = AskForNumber(text);
    }
    while (number < min || number > max);

    return number;
}