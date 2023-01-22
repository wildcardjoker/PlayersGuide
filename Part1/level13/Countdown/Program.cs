Console.Title = "Countdown";
Console.WriteLine("Countd-o-o-o-wn!");
var countdownFrom = 10;
Countdown(countdownFrom);

void Countdown(int i)
{
    if (i == 0)
    {
        return;
    }

    Console.WriteLine(i);
    Countdown(--i);
}