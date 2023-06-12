#region Using Directives
using sieve;
#endregion

bool EvenDelegate(int     number) => number % 2  == 0;
bool PositiveDelegate(int number) => number      > 0;
bool DenaryDelegate(int   number) => number % 10 == 0;
var validChoices = new[] {ConsoleKey.D1, ConsoleKey.NumPad1, ConsoleKey.D2, ConsoleKey.NumPad2, ConsoleKey.D3, ConsoleKey.NumPad3};

Console.Title = "The Sieve";
Console.WriteLine("Please select your filter:");
Console.WriteLine("1) Even Numbers");
Console.WriteLine("2) Positive Numbers");
Console.WriteLine("3) Denary Numbers (multiple of 10)");
var selection = GetValidInput();
NumeromechanicalDelegate? compareFunction = selection switch
{
    ConsoleKey.D1 or ConsoleKey.NumPad1 => EvenDelegate,
    ConsoleKey.D2 or ConsoleKey.NumPad2 => PositiveDelegate,
    ConsoleKey.D3 or ConsoleKey.NumPad3 => DenaryDelegate,
    _                                   => null
};

var sieve = new Sieve(compareFunction!); // Never null - GetValidInput() ensures that.
CheckNumber();

// End of main method.

// Note: A delegate for the method bool MyDelegate(int number) can be declared in the following ways:
// Custom:    delegate bool MyDelegate(int number)
// Func:      Func<int, bool> MyDelegate(int number)
// Predicate: Predicate<int> MyDelegate(int number)
// If parameters are not required, use Func<TResult> to return a value.
// If a return value is not required, use Action<T> where T is your value type.

// Answer this question: Describe how you could have also solved this problem with inheritance and polymorphism. Which solution seems more straightforward to you, and why?
// Using inheritance, the base class would include a virtual method for 'IsGood', and be implemented by three distinct classes.
// If another filter was to be added, a new class would need to be added and supported.
// Using a delegate allows for a single class to be created, which can accept a limitless variety of methods as a parameter. This greatly simplifies the code, and makes debugging much easier.

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

void CheckNumber()
{
    var quit = false;
    do
    {
        Console.Write("\nPlease enter a number to check (q to quit): ");
        var input = Console.ReadLine();
        quit = input?.ToUpper().Equals("Q") ?? false;
        _    = int.TryParse(input, out var number); // Discard success check.
        if (number != 0)
        {
            Console.WriteLine($"{number} is {GetNumberStatus(sieve.IsGood(number))}");
        }
    }
    while (!quit);
}

string GetNumberStatus(bool result) => result ? "Good" : "Bad";