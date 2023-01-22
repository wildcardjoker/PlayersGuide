// ReSharper disable FieldCanBeMadeReadOnly.Local

var title     = "The Properties of Arrows";
var minLength = 60;
var maxLength = 100;
Console.Title = title;
Console.WriteLine(title);
DisplayArrowHeadTypes();
var arrowHead = (ArrowHeadType) AskForNumberInRange("Which arrowhead type would you like", 1, 3);
DisplayFletchingTypes();
var fletching = (FletchingType) AskForNumberInRange("Which fletching would you like", 1, 3);
var length    = AskForNumberInRange($"How long would you like your arrow ({minLength} - {maxLength})", minLength, maxLength);
var arrow     = new Arrow(arrowHead, fletching, length);

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"\n\nAn arrow with a {arrow.ArrowHead} head and {arrow.Fletching} fletching, of length {arrow.Length}cm will cost {arrow.Cost} gold");
Console.ResetColor();

void DisplayArrowHeadTypes()
{
    Console.WriteLine("\nThe following arrowheads are available:");
    Console.WriteLine($"{(int) ArrowHeadType.Steel} - {ArrowHeadType.Steel}");
    Console.WriteLine($"{(int) ArrowHeadType.Wood} - {ArrowHeadType.Wood}");
    Console.WriteLine($"{(int) ArrowHeadType.Obsidian} - {ArrowHeadType.Obsidian}");
}

void DisplayFletchingTypes()
{
    Console.WriteLine("\nThe following fletchings are available:");
    Console.WriteLine($"{(int) FletchingType.Plastic} - {FletchingType.Plastic}");
    Console.WriteLine($"{(int) FletchingType.TurkeyFeathers} - {FletchingType.TurkeyFeathers}");
    Console.WriteLine($"{(int) FletchingType.GooseFeathers} - {FletchingType.GooseFeathers}");
}

int AskForNumber(string text)
{
    Console.Write($"{text}? "); // Add a space to the end of the question
    return Convert.ToInt32(Console.ReadLine());
}

int AskForNumberInRange(string text, int min, int max)
{
    int number;
    do
    {
        number = AskForNumber(text);
    }
    while (number < min || number > max);

    return number;
}

/// <summary>
///     The Arrow class - includes all properties required to make an arrow.
/// </summary>
internal class Arrow
{
    #region Fields
    // There are better ways to handle information hiding.
    // We'll go with the book's recommendations here, and acknowledge that this isn't out normal coding style.
    public readonly ArrowHeadType ArrowHead;
    public readonly FletchingType Fletching;
    public readonly int           Length;
    #endregion

    #region Constructors
    public Arrow() : this(ArrowHeadType.Wood, FletchingType.GooseFeathers, 60) {}

    public Arrow(ArrowHeadType arrowHead, FletchingType fletching, int length)
    {
        ArrowHead = arrowHead;
        Fletching = fletching;
        Length    = length;
    }
    #endregion

    #region Properties
    public float Cost => ArrowHeadCost + FletchingCost + Length * 0.05f;

    private int ArrowHeadCost
    {
        get
        {
            var arrowHeadCost = ArrowHead switch
            {
                ArrowHeadType.Wood     => 3,
                ArrowHeadType.Obsidian => 5,
                ArrowHeadType.Steel    => 10,
                _                      => 0
            };
            return arrowHeadCost;
        }
    }

    private int FletchingCost
    {
        get
        {
            var fletchingCost = Fletching switch
            {
                FletchingType.GooseFeathers  => 3,
                FletchingType.Plastic        => 10,
                FletchingType.TurkeyFeathers => 5, _ => 0
            };
            return fletchingCost;
        }
    }
    #endregion
}

internal enum ArrowHeadType
{
    Steel = 1,
    Wood,
    Obsidian
}

internal enum FletchingType
{
    Plastic = 1,
    TurkeyFeathers,
    GooseFeathers
}