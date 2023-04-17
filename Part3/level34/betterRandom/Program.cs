#region Using Directives
using betterRandom;
#endregion

var strings = new[] {"up", "down", "left", "right"};
var random  = new Random();

ProcessDoubles();

Console.WriteLine($"Next String: {random.NextString(strings)}");
Console.WriteLine($"Coin Flip  : {(random.CoinFlip() ? "Heads" : "Tails")}");

#region Double
void ProcessDoubles()
{
    var numberOfDoubles = GetNumberOfRandomObjects("double", 10);
    var doubleMaximum   = GetDoubleMaximum();
    WriteDoubles(numberOfDoubles, doubleMaximum);
}

void WriteDoubles(int cycles, double maximum)
{
    for (var i = 0; i < cycles; i++)
    {
        Console.WriteLine($"Next Double: {random.NextDouble(maximum)}");
    }
}

double GetDoubleMaximum()
{
    Console.Write("What is the maximum for your Double values? ");
    double.TryParse(Console.ReadLine(), out var result);
    return result;
}
#endregion

int GetNumberOfRandomObjects(string objectDescription, int defaultNumber)
{
    Console.Write($"How many {objectDescription} objects? (default: {defaultNumber})? ");
    if (!int.TryParse(Console.ReadLine(), out var result))
    {
        result = defaultNumber;
    }

    return result;
}