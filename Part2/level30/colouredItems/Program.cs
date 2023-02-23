public class Sword {}

public class Bow {}

public class Axe {}

/// <summary>
///     Assign a colour to any item type.
/// </summary>
/// <typeparam name="T">The item type to be coloured.</typeparam>
public class ColouredItem<T>
{
    #region Properties
    private ConsoleColor Color {get; init;}
    #endregion

    /// <summary>
    ///     Change the console colour to the object's specified colour.
    /// </summary>
    public void Display()
    {
        Console.ForegroundColor = Color;
    }
}