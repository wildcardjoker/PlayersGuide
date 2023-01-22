var title     = "Vin Fletcher's Arrows";
var arrow     = new Arrow();
var minLength = 60;
var maxLength = 100;
Console.Title = title;
Console.WriteLine(title);
DisplayArrowHeadTypes();
arrow.ArrowHead = (ArrowHeadType) AskForNumberInRange("Which arrowhead type would you like", 1, 3);
DisplayFletchingTypes();
arrow.Fletching = (FletchingType) AskForNumberInRange("Which fletching would you like", 1, 3);
arrow.Length    = AskForNumberInRange($"How long would you like your arrow ({minLength} - {maxLength})", minLength, maxLength);

// Use string formatting to show the cost in a currency format
Console.WriteLine($"\n\nYour arrow will cost {arrow.GetCost():C}");

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
    public ArrowHeadType ArrowHead;
    public FletchingType Fletching;
    public int           Length;
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

    public float GetCost()
    {
        var arrowHeadCost = ArrowHead switch
        {
            ArrowHeadType.Wood     => 3,
            ArrowHeadType.Obsidian => 5,
            ArrowHeadType.Steel    => 10
        };

        var fletchingCost = Fletching switch
        {
            FletchingType.GooseFeathers  => 3,
            FletchingType.Plastic        => 10,
            FletchingType.TurkeyFeathers => 5
        };
        return arrowHeadCost + fletchingCost + Length * 0.05f;
    }
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