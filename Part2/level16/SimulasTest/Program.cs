var title = "Simula's Test";
Console.Title = title;
Console.WriteLine($"{title}\n");

var state = ChestState.Locked;
while (true)
{
    RequestAction();
}

void RequestAction()
{
    string action;
    do
    {
        Console.Write($"The chest is {state}. What do you want to do? ");
        action = Console.ReadLine();
        if (action == null)
        {
            action = string.Empty;
        }
    }
    while (!CanPerformAction(action));

    ChangeState(action);
}

bool CanPerformAction(string action)
{
    switch (state)
    {
        case ChestState.Open:
            return action == "close";
        case ChestState.Closed:
            return action == "open" || action == "lock";
        case ChestState.Locked:
            return action == "unlock";
        default:
            throw new ArgumentOutOfRangeException();
    }
}

void ChangeState(string action)
{
    switch (action)
    {
        case "close":
        case "unlock":
            state = ChestState.Closed;
            break;
        case "open":
            state = ChestState.Open;
            break;
        case "lock":
            state = ChestState.Locked;
            break;
    }
}

internal enum ChestState
{
    Open,
    Closed,
    Locked
}