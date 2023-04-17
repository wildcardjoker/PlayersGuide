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
    var numberOfDoubles = GetNumberOfRandomDoubles();
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

int GetNumberOfRandomDoubles()
{
    Console.Write("How many doubles (default: 10)? ");
    if (!int.TryParse(Console.ReadLine(), out var result))
    {
        result = 10;
    }

    return result;
}

double GetDoubleMaximum()
{
    Console.Write("What is the maximum for your Double values? ");
    double.TryParse(Console.ReadLine(), out var result);
    return result;
}
#endregion