var initialPasscode = Door.AskForNumber("What would you like to set the Door's passcode to");
var door            = new Door(initialPasscode);

while (true)
{
    var action = door.DisplayDoorStatusAndAskForAction();
    if (action == Action.ChangePasscode || (action == Action.Unlock && door.DoorStatus == Status.Locked))
    {
        var currentPasscode = Door.AskForNumber("What is the current passcode");
        var newPasscode     = 0;
        if (action == Action.ChangePasscode)
        {
            newPasscode = Door.AskForNumber("What is the new passcode");
        }

        Console.WriteLine(door.PerformAction(action, currentPasscode, newPasscode));
    }
    else
    {
        Console.WriteLine(door.PerformAction(action));
    }
}

public class Door
{
    #region Constructors
    public Door(int passCode)
    {
        DoorStatus = Status.Open;
        PassCode   = passCode;
    }
    #endregion

    #region Properties
    public Status DoorStatus {get; private set;}
    public int    PassCode   {get; private set;}
    #endregion

    public static int AskForNumber(string text)
    {
        Console.Write($"{text}? ");
        return Convert.ToInt32(Console.ReadLine());
    }

    public Action DisplayDoorStatusAndAskForAction()
    {
        DisplayDoorStatus();
        DisplayActions();
        Console.Write("What is your command? ");
        var action = Console.ReadLine();
        return action switch
        {
            "Open"            => Action.Open,
            "Close"           => Action.Close,
            "Lock"            => Action.Lock,
            "Unlock"          => Action.Unlock,
            "Change Passcode" => Action.ChangePasscode,
            _                 => Action.Open
        };
    }

    public string PerformAction(Action action) => PerformAction(action, 0, 0);

    public string PerformAction(Action action, int passCode, int newPassCode)
    {
        var response = action switch
        {
            Action.ChangePasscode => ChangePassCode(passCode, newPassCode),
            Action.Open           => Open(),
            Action.Close          => Close(),
            Action.Lock           => Lock(),
            Action.Unlock         => Unlock(passCode),
            _                     => "Sorry, that item isn't on the list."
        };
        return response;
    }

    private string ChangePassCode(int passCode, int newPassCode)
    {
        if (PassCode != passCode)
        {
            return "You failed to supply the correct passcode.";
        }

        PassCode = newPassCode;
        return "You changed the passcode.";
    }

    private string Close()
    {
        // An open door can always be closed.
        switch (DoorStatus)
        {
            case Status.Open:
                DoorStatus = Status.Closed;
                return "You close the door.";
            case Status.Closed:
                return "The door is already closed.";
            default:
                return "You cannot close the door at this time.";
        }
    }

    private void DisplayActions()
    {
        Console.WriteLine("You can choose from the following commands: Open, Close, Lock, Unlock, Change Passcode");
    }

    private void DisplayDoorStatus() => Console.WriteLine($"The door is {DoorStatus}");

    private string Lock()
    {
        // A closed (but not locked) door can always be locked.
        switch (DoorStatus)
        {
            case Status.Closed:
                DoorStatus = Status.Locked;
                return "You lock the door.";
            case Status.Locked:
                return "The door is already locked.";
            default:
                return "You cannot lock the door at this time.";
        }
    }

    private string Open()
    {
        switch (DoorStatus)
        {
            // A closed (but not locked) door can always be opened.
            case Status.Closed:
                DoorStatus = Status.Open;
                return "You open the door.";
            case Status.Open:
                return "The door is already open.";
            default:
                return "You cannot open the door at this time.";
        }
    }

    private string Unlock(int passcode)
    {
        //- A locked door can be unlocked, but a numeric passcode is needed, and the door will only unlock if the code supplied matches the door's current passcode.
        if (DoorStatus == Status.Locked && PassCode == passcode)
        {
            DoorStatus = Status.Closed;
            return "You unlock the door.";
        }

        switch (DoorStatus)
        {
            case Status.Locked:
                return "You didn't enter the correct passcode.";
            case Status.Closed:
                return "The door is already unlocked.";
            default:
                return "You cannot unlock the door at this time.";
        }
    }
}

public enum Action
{
    Open,
    Close,
    Lock,
    Unlock,
    ChangePasscode
}

public enum Status
{
    Closed,
    Locked,
    Open
}