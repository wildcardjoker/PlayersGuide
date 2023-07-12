#region Using Directives
#endregion

#region Using Directives
using lambdaSieve;
#endregion

var validChoices = new[] {ConsoleKey.D1, ConsoleKey.NumPad1, ConsoleKey.D2, ConsoleKey.NumPad2, ConsoleKey.D3, ConsoleKey.NumPad3};

Console.Title = "The Sieve";
Console.WriteLine("Please select your filter:");
Console.WriteLine("1) Even Numbers");
Console.WriteLine("2) Positive Numbers");
Console.WriteLine("3) Denary Numbers (multiple of 10)");
var selection = GetValidInput();
NumeromechanicalDelegate? compareFunction = selection switch
{
    ConsoleKey.D1 or ConsoleKey.NumPad1 => x => x % 2  == 0,
    ConsoleKey.D2 or ConsoleKey.NumPad2 => x => x      > 0,
    ConsoleKey.D3 or ConsoleKey.NumPad3 => x => x % 10 == 0,
    _                                   => null
};

// Answer this question: Does this change make the program shorter or longer?
// The program is shorter, as the function is defined inline.

// Answer this question: Does this change make the program easier to read or harder?
// It depends on your coding style. Personally, I prefer the lambda method. However, others may prefer the full method statement.

var sieve = new Sieve(compareFunction!); // Never null - GetValidInput() ensures that.
CheckNumber();

// End of main method.

// Note: A delegate for the method bool MyDelegate(int number) can be declared in the following ways:
// Custom:    delegate bool MyDelegate(int number)
// Func:      Func<int, bool> MyDelegate(int number)
// Predicate: Predicate<int> MyDelegate(int number)
// If parameters are not required, use Func<TResult> to return a value.
// If a return value is not required, use Action<T> where T is your value type.

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