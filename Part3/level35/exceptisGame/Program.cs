// Hooray, Error Handling! :)

Console.Title = "Excepti's Game";
var random          = new Random();
var oatmealCookie   = random.Next(0, 10); // Choose between 0 - 9
var previousChoices = new List<int>();
var playerNumber    = 1;
var cookieChoice    = -1;

while (cookieChoice != oatmealCookie)
{
    cookieChoice = GetCookieChoice();
    SwitchPlayer();
}

// throw exception
Console.WriteLine("Oatmeal cookie found!");
Console.WriteLine($"Player {playerNumber} wins!");

int GetCookieChoice()
{
    var choice = -1;
    while (choice < 0 || choice > 9)
    {
        Console.Write($"Player {playerNumber}, please choose a cookie between 0 and 9: ");
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            choice = -1;
        }
    }

    return choice;
}

void SwitchPlayer()
{
    playerNumber = playerNumber == 1 ? 2 : 1;
}