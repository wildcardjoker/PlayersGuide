#region Using Directives
using Humanizer;
#endregion

Console.WriteLine($"When is the feast? {DateTime.UtcNow.AddHours(30)}");
Console.WriteLine($"When is the feast? {DateTime.UtcNow.AddHours(30).Humanize()}");
Console.WriteLine($"When is the feast? {DateTime.UtcNow.AddHours(2.5).Humanize()}");
Console.WriteLine($"When is the feast? {DateTime.UtcNow.AddHours(50).Humanize()}");