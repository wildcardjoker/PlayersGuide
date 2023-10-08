// Example program demonstrating the use of multi-threading.

#region Using Directives
using repeatingStream;
#endregion

var mostRecentNumbers = new RecentNumbers();
var thread            = new Thread(mostRecentNumbers.GenerateInfiniteNumbers);

thread.Start();
while (true)
{
    Console.ReadKey();
    Console.WriteLine(mostRecentNumbers.RepeatNumberDetected() ? "Repeat number detected!" : "Not a repeating number, sorry");
}