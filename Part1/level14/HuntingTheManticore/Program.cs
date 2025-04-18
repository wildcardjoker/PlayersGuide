﻿Console.Title = "Hunt the Manticore";

// Establish the game's starting state: the Manticore begins with 10 health points and the city with 15. The game starts at round 1.
// These variables are accessible to local functions, so we don't need to pass them as parameters.
var maxManticoreHealth = 10;
var minManticoreHealth = 0;
var maxCityHealth      = 15;
var minCityHealth      = 0;
var currentRound       = 1;
var manticoreHealth    = maxManticoreHealth;
var cityHealth         = maxCityHealth;
var fireRound          = 3;
var electricRound      = 5;
var electricFireRound  = fireRound * electricRound;
var standardDamage     = 1;
var bonusDamage        = 3;
var majorDamage        = 10;
var minRange           = 0;
var maxRange           = 100;

// Ask the first player to choose the Manticore's distance from the city (0 to 100). Clear the screen afterward.
var manticoreLocation = AskForManticoreLocation("Player 1, how far away from the city to you want to station the Manticore");
Console.Clear();

// Run the game in a loop until either the Manticore's or city's health reaches `0`.
do
{
    DisplayStatus();
    var manticoreLocationEstimate = AskForManticoreLocation("Enter desired cannon range");
    ShootCannon(manticoreLocationEstimate);
    currentRound++;
}
while (cityHealth > minCityHealth && manticoreHealth > minManticoreHealth);

// Something has been destroyed - either the Manticore, or the city.
// Advise the player of the outcome.
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(
    cityHealth > minCityHealth
        ? "The Manticore has been destroyed! The city of Consolas has been saved!"
        : "The city has been destroyed, reduced to a pile of rubble.\nThe Uncoded One laughs at your pitiful defences.");
Console.ResetColor();

// End of application

// Methods

// Accept input from the console and convert it to an integer.
// Still no error handling
int AskForNumber(string text)
{
    Console.Write($"{text}? ");
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

// Ask for the location of the Manticore
int AskForManticoreLocation(string text) => AskForNumberInRange($"{text} ({minRange} - {maxRange})", minRange, maxRange);

// Display the status for the current round
void DisplayStatus()
{
    var damage = CalculateDamage();
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine($"STATUS: Round: {currentRound}  City: {cityHealth}/{maxCityHealth}  Manticore: {manticoreHealth}/{maxManticoreHealth}");
    Console.WriteLine($"The cannon is expected to deal {damage} damage this round.");
}

// Determines whether the current round deals Electric Fire damage
bool IsElectricFireRound() => currentRound % electricFireRound == 0;

// Determines whether the current round deals Electric damage
bool IsElectricRound() => currentRound % electricRound == 0;

// Determines whether the current round deals Fire damage
bool IsFireRound() => currentRound % fireRound == 0;

// Calculate the damage to the Manticore if the hunter scores a hit this round.
int CalculateDamage() => IsElectricFireRound() ? majorDamage : IsElectricRound() || IsFireRound() ? bonusDamage : standardDamage;

// Determine the console colour by the Round damage type
ConsoleColor GetDamageColour() =>
    IsElectricFireRound() ? ConsoleColor.Green : IsElectricRound() ? ConsoleColor.Cyan : IsFireRound() ? ConsoleColor.Red : ConsoleColor.White;

// Fire at the Manticore
void ShootCannon(int location)
{
    if (location == manticoreLocation)
    {
        Console.Write("That round was a ");
        Console.ForegroundColor = GetDamageColour();
        Console.WriteLine($"DIRECT HIT for {CalculateDamage()} damage!");
        Console.ResetColor();
        manticoreHealth -= CalculateDamage();
    }
    else
    {
        Console.Write("That round ");
        if (location < manticoreLocation)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("FELL SHORT of");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("OVERSHOT");
        }

        Console.ResetColor();
        Console.WriteLine(" the range.");
    }

    // If the Manticore is still alive, reduce the city's health by 1
    if (manticoreHealth > minManticoreHealth)
    {
        cityHealth--;
    }
}