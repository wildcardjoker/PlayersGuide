// duelingTraditions

namespace duelingTraditions;

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
    private T            Item       {get; set;}
    private ConsoleColor ItemColour {get;}
    #endregion

    /// <summary>
    ///     Change the console colour to the object's specified colour.
    /// </summary>
    public void Display(bool newLine = true)
    {
        Console.ForegroundColor = ItemColour;
        Console.Write(Item?.ToString());
        if (newLine)
        {
            Console.WriteLine();
        }
    }

    /// <summary>
    ///     Gets the input.
    /// </summary>
    /// <returns></returns>
    public string? GetInput()
    {
        Console.ForegroundColor = ItemColour;
        return Console.ReadLine();
    }

    /// <summary>
    ///     Update the item related to this object.
    /// </summary>
    /// <param name="item">The item.</param>
    public void SetItem(T item) => Item = item;

    #region Overrides of Object
    /// <inheritdoc />
    public override string? ToString() => Item?.ToString();
    #endregion
}