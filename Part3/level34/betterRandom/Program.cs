#region Using Directives
using betterRandom;
#endregion

var strings = new[] {"up", "down", "left", "right"};
var random  = new Random();

ProcessDoubles();
ProcessStrings();
ProcessCoinFlips();

int GetNumberOfRandomObjects(string objectDescription, int defaultNumber = 10)
{
    Console.Write($"\nHow many {objectDescription} objects? (default: {defaultNumber})? ");
    if (!int.TryParse(Console.ReadLine(), out var result))
    {
        result = defaultNumber;
    }

    return result;
}

#region Double
void ProcessDoubles()
{
    var numberOfDoubles = GetNumberOfRandomObjects("double");
    var doubleMaximum   = GetDoubleMaximum("What is the maximum for your Double values?");
    WriteDoubles(numberOfDoubles, doubleMaximum);
}

void WriteDoubles(int cycles, double maximum)
{
    maximum = maximum == 0 ? 1 : maximum;
    for (var i = 0; i < cycles; i++)
    {
        Console.WriteLine($"Next Double: {random.NextDouble(maximum)}");
    }
}

double GetDoubleMaximum(string s)
{
    Console.Write($"{s} ");
    double.TryParse(Console.ReadLine(), out var result);
    return result;
}
#endregion

#region Strings
void ProcessStrings() => WriteStrings(GetNumberOfRandomObjects("string"));

void WriteStrings(int cycles)
{
    for (var i = 0; i < cycles; i++)
    {
        Console.WriteLine($"Next string: {random.NextString(strings)}");
    }
}
#endregion

#region Coin Flip
void ProcessCoinFlips()
{
    var numberOfFlips  = GetNumberOfRandomObjects("coin flip", 100);
    var headsFrequency = GetDoubleMaximum("How often should Heads show? Default is 0.5 (50%):");
    Console.Write("Show individual results [Y/N]? ");
    var showIndividualResults = Console.ReadLine()?.ToUpper().Equals("Y") ?? false;

    var headCount = 0;
    var tailCount = 0;
    for (var i = 0; i < numberOfFlips; i++)
    {
        var coinFlipResult = random.CoinFlip(headsFrequency == 0 ? 0.5 : headsFrequency);
        if (showIndividualResults)
        {
            Console.WriteLine($"Coin Flip  : {(coinFlipResult ? "Heads" : "Tails")}");
        }

        if (coinFlipResult)
        {
            headCount++;
        }
        else
        {
            tailCount++;
        }
    }

    Console.WriteLine("\nResults:");

    Console.WriteLine($"Heads: {headCount} ({GetPercent(headCount, numberOfFlips)} %)");
    Console.WriteLine($"Tails: {tailCount} ({GetPercent(tailCount, numberOfFlips)} %)");
}

double GetPercent(int count, int max) => Math.Round((double) count / max * 100, 2);
#endregion