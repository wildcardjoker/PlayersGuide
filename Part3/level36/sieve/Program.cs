#region Using Directives
using sieve;
#endregion

bool EvenDelegate(int     number) => number % 2  == 0;
bool PositiveDelegate(int number) => number      > 0;
bool DenaryDelegate(int   number) => number % 10 == 0;

Func<int, bool> compareFunction = null;
Console.Title = "The Sieve";
Console.WriteLine("Please select your filter:");
;
Console.WriteLine("1) Even Numbers");
Console.WriteLine("2) Positive Numbers");
Console.WriteLine("3) Denary Numbers (multiple of 10)");
Console.Write("\n Please choose 1-3: ");
var filterChoice = Console.ReadKey().Key;
switch (filterChoice)
{
    case ConsoleKey.D1:
    case ConsoleKey.NumPad1:
        compareFunction = EvenDelegate;
        break;
    case ConsoleKey.D2:
    case ConsoleKey.NumPad2:
        compareFunction = PositiveDelegate;
        break;
    case ConsoleKey.D3:
    case ConsoleKey.NumPad3:
        compareFunction = DenaryDelegate;
        break;
}

if (compareFunction == null)
{
    Console.WriteLine("Not a valid selection!");
    return;
}

var sieve = new Sieve(compareFunction);
Console.WriteLine($"\n1 is {sieve.IsGood(1)}");
Console.WriteLine($"2 is {sieve.IsGood(2)}");
Console.WriteLine($"10 is {sieve.IsGood(10)}");