#region Using Directives
using sieve;
#endregion

bool EvenDelegate(int     number) => number % 2  == 0;
bool PositiveDelegate(int number) => number      > 0;
bool DenaryDelegate(int   number) => number % 10 == 0;
var validChoices = new[] {ConsoleKey.D1, ConsoleKey.NumPad1, ConsoleKey.D2, ConsoleKey.NumPad2, ConsoleKey.D3, ConsoleKey.NumPad3};

Func<int, bool>? compareFunction = null;
Console.Title = "The Sieve";
Console.WriteLine("Please select your filter:");
Console.WriteLine("1) Even Numbers");
Console.WriteLine("2) Positive Numbers");
Console.WriteLine("3) Denary Numbers (multiple of 10)");
var selection = GetValidInput();
compareFunction = selection switch
{
    ConsoleKey.D1 or ConsoleKey.NumPad1 => EvenDelegate,
    ConsoleKey.D2 or ConsoleKey.NumPad2 => PositiveDelegate,
    ConsoleKey.D3 or ConsoleKey.NumPad3 => DenaryDelegate,
    _                                   => null
};

var sieve = new Sieve(compareFunction!); // Never null - GetValidInput() ensures that.
Console.WriteLine($"\n1 is {sieve.IsGood(1)}");
Console.WriteLine($"2 is {sieve.IsGood(2)}");
Console.WriteLine($"10 is {sieve.IsGood(10)}");

ConsoleKey GetValidInput()
{
    // Take the next keystroke from the console and attempt to locate the desired filter.
    // Continue until the user selects 1-3
    var filterChoice = ConsoleKey.NoName;
    while (!IsValidFilter(filterChoice))
    {
        Console.Write("\n Please choose 1-3: ");
        filterChoice = Console.ReadKey().Key;
    }

    return filterChoice;
}

bool IsValidFilter(ConsoleKey choice) => validChoices.Contains(choice);