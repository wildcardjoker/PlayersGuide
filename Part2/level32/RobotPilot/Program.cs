Console.Title = "Hunt the Manticore";

// Establish the game's starting state: the Manticore begins with 10 health points and the city with 15. The game starts at round 1.
// These variables are accessible to local functions, so we don't need to pass them as parameters.
const int maxManticoreHealth = 10;
const int minManticoreHealth = 0;
const int maxCityHealth      = 15;
const int minCityHealth      = 0;
const int fireRound          = 3;
const int electricRound      = 5;
const int electricFireRound  = fireRound * electricRound;
const int standardDamage     = 1;
const int bonusDamage        = 3;
const int majorDamage        = 10;
const int minRange           = 0;
const int maxRange           = 100;
var       currentRound       = 1;
var       manticoreHealth    = maxManticoreHealth;
var       cityHealth         = maxCityHealth;

// Human or computer player?
var response = ConsoleKey.NoName;
while (!response.Equals(ConsoleKey.S) && !response.Equals(ConsoleKey.M))
{
    Console.Write("Do you want to play (S)ingle player or (M)ultiplayer? ");
    response = Console.ReadKey().Key;
    Console.WriteLine();
}

// Set up Player 2
IPlayer player            = response.Equals(ConsoleKey.S) ? new ComputerPlayer() : new HumanPlayer();
var     manticoreLocation = player.GetLocation(minRange, maxRange);

// Run the game in a loop until either the Manticore's or city's health reaches `0`.
do
{
    DisplayStatus();
    var manticoreLocationEstimate = Helper.AskForManticoreLocation("Enter desired cannon range", minRange, maxRange);
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

// Answer this question: How might you use inheritance, polymorphism, or interfaces to allow the game to be single player or two players?
// Answer: I've created a Player interface, which has a single method and is implemented by two classes:
// ComputerPlayer: The GetLocation() method uses a random number generator to determine the Manticore's location.
// HumanPlayer: The GetLocation() method uses the console to ask the player for the Manticore's location.
// Using these classes, the application can allow the player to choose a single or multi player game, and generate a starting location for the Manticore.
// As both the main application and the HumanPlayer use the AskForManticoreLocation() method, I've also moved those methods into a static class which can be accessed by both the main application and the HumanPlayer class.

// Interface for Player 2
internal interface IPlayer
{
    int GetLocation(int min, int max);
}

/// <summary>
///     A Computer player - the Manticore's location is determined by the Random Number Generator.
/// </summary>
public class ComputerPlayer : IPlayer
{
    #region IPlayer Members
    /// <summary>
    ///     Gets the location of the Manticore.
    /// </summary>
    /// <param name="min">The minimum range.</param>
    /// <param name="max">The maximum range.</param>
    /// <returns></returns>
    public int GetLocation(int min, int max)
    {
        var random = new Random();
        return random.Next(min, max + 1);
    }
    #endregion
}

/// <summary>
///     A Human player - the Manticore's location is determined by the user inputting a range.
///     The console is then cleared so that the game can begin.
/// </summary>
public class HumanPlayer : IPlayer
{
    #region IPlayer Members
    #region Implementation of IPlayer
    /// <inheritdoc />
    public int GetLocation(int min, int max)
    {
        // Ask the first player to choose the Manticore's distance from the city (0 to 100). Clear the screen afterward.
        var manticoreLocation = Helper.AskForManticoreLocation("Player 1, how far away from the city to you want to station the Manticore", min, max);
        Console.Clear();
        return manticoreLocation;
    }
    #endregion
    #endregion
}

/// <summary>
///     Helper functions
/// </summary>
public static class Helper
{
    // Ask for the location of the Manticore
    /// <summary>
    ///     Asks for the Manticore's location.
    /// </summary>
    /// <param name="text">The text to be displayed.</param>
    /// <param name="minRange">The minimum range.</param>
    /// <param name="maxRange">The maximum range.</param>
    /// <returns></returns>
    public static int AskForManticoreLocation(string text, int minRange, int maxRange) => AskForNumberInRange($"{text} ({minRange} - {maxRange})", minRange, maxRange);

    // Accept input from the console and convert it to an integer.
    // Still no error handling
    private static int AskForNumber(string text)
    {
        Console.Write($"{text}? ");
        return Convert.ToInt32(Console.ReadLine());
    }

    // Prompt user for a number within the specified range until a valid input is provided
    private static int AskForNumberInRange(string text, int min, int max)
    {
        int number;
        do
        {
            number = AskForNumber(text);
        }
        while (number < min || number > max);

        return number;
    }
}