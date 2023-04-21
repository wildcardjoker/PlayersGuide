// Hooray, Error Handling! :)

Console.Title = "Excepti's Game";
var random          = new Random();
var oatmealCookie   = random.Next(0, 10); // Choose between 0 - 9
var previousChoices = new List<int>();
var playerNumber    = 1;
var cookieChoice    = -1;

try
{
    while (cookieChoice != oatmealCookie)
    {
        cookieChoice = GetCookieChoice();
        SwitchPlayer();
    }

    throw new OatmealCookieFoundException("Oatmeal cookie found!");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
finally
{
    Console.WriteLine($"Player {playerNumber} wins!");
}

// Answer this question: Did you make a custom exception type or use an existing one, and why did you choose what you did?
// I created a custom Exception because it is more descriptive. Plus, given the exercise at hand, it's a good idea to have sample code of a custom Exception.

//Answer this question: You could write this program without exceptions, but the requirements demanded an exception for learning purposes.
//If you didn't have that requirement, would you have used an exception? Why or why not?
// No. Exceptions should only be thrown as a result of an error that can't be resolved.
// In this instance, the code is more readable and maintainable by using a simple conditional check:

//while (cookieChoice != oatmealCookie)
//{
//    cookieChoice = GetCookieChoice();
//    SwitchPlayer();
//}

//Console.WriteLine("Oatmeal cookie found!");
//Console.WriteLine($"Player {playerNumber} wins!");

int GetCookieChoice()
{
    var choice = -1;
    while (!IsValidChoice(choice))
    {
        Console.Write($"Player {playerNumber}, please choose a cookie between 0 and 9: ");
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            choice = -1;
        }
    }

    previousChoices.Add(choice);
    return choice;
}

bool IsValidChoice(int selectedCookie)
{
    if (previousChoices.Contains(selectedCookie))
    {
        Console.WriteLine($"Cookie #{selectedCookie} has already been eaten. Choose again.");
        return false;
    }

    return selectedCookie >= 0 && selectedCookie <= 9;
}

void SwitchPlayer()
{
    playerNumber = playerNumber == 1 ? 2 : 1;
}