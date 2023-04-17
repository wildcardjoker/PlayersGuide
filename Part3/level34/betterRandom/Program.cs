#region Using Directives
using betterRandom;
#endregion

var strings = new[] {"up", "down", "left", "right"};
var random  = new Random();

Console.WriteLine($"Next Double: {random.NextDouble()}");
Console.WriteLine($"Next String: {random.NextString(strings)}");
Console.WriteLine($"Coin Flip  : {(random.CoinFlip() ? "Heads" : "Tails")}");