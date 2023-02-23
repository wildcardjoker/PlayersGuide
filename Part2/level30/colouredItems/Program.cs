var sword = new ColouredItem<Sword>(new Sword(), ConsoleColor.Blue);
var bow   = new ColouredItem<Bow>(new Bow(), ConsoleColor.Red);
var axe   = new ColouredItem<Axe>(new Axe(), ConsoleColor.Green);

Console.WriteLine("Before you, you see the following items:");
sword.Display();
bow.Display();
axe.Display();
Console.ResetColor();

public class Sword {}

public class Bow {}

public class Axe {}

/// <summary>
///     Assign a colour to any item type.
/// </summary>
/// <typeparam name="T">The item type to be coloured.</typeparam>
public class ColouredItem<T>
{
    #region Constructors
    /// <summary>
    ///     Initializes a new instance of the <see cref="ColouredItem{T}" /> class.
    /// </summary>
    /// <param name="item">The item to be colourised.</param>
    /// <param name="color">The color.</param>
    public ColouredItem(T item, ConsoleColor color)
    {
        Item       = item;
        ItemColour = color;
    }
    #endregion

    #region Properties
    private T            Item       {get;}
    private ConsoleColor ItemColour {get;}
    #endregion

    /// <summary>
    ///     Change the console colour to the object's specified colour.
    /// </summary>
    public void Display()
    {
        Console.ForegroundColor = ItemColour;
        Console.WriteLine(Item?.ToString());
    }
}