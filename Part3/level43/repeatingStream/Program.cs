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
    Console.WriteLine("Key pressed. Check duplicates");
}