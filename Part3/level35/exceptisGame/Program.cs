// Hooray, Error Handling! :)

Console.Title = "Excepti's Game";
var random          = new Random();
var oatmealCookie   = random.Next(0, 10); // Choose between 0 - 9
var previousChoices = new List<int>();
var playerNumber    = 1;

// Get player 1's cookie choice
// Check against oatmeal cookie

var cookieChoice = GetCookieChoice();

int GetCookieChoice()
{
    var choice = -1;
    while (choice < 0 || choice > 9)
    {
        Console.Write("Choose a cookie between 0 and 9: ");
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            choice = -1;
        }
    }

    return choice;
}