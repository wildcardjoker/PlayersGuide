// Example program demonstrating the use of multi-threading.

#region Using Directives
using repeatingStream;
#endregion

var rnd               = new Random();
var mostRecentNumbers = new RecentNumbers();

while (true)
{
    GenerateNumber();
}

void GenerateNumber()
{
    var number = rnd.Next(0, 10); // 0 - 9
    mostRecentNumbers.AddNumber(number);
    Console.WriteLine(number);
    Thread.Sleep(1000); // Sleep one second.
}