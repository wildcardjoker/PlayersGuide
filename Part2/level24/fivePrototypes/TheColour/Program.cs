var colourA = new Colour(128, 128, 128); // Grey
var colourB = Colour.CreatePurple();

Console.WriteLine($"Colour A (custom grey)    : {colourA.DisplayRGBValue()}");
Console.WriteLine($"Colour B (standard purple): {colourB.DisplayRGBValue()}");

public class Colour
{
    #region Constructors
    public Colour(int red, int green, int blue)
    {
        Red   = red;
        Green = green;
        Blue  = blue;
    }
    #endregion

    #region Properties
    public int Blue  {get;}
    public int Green {get;}
    public int Red   {get;}
    #endregion

    public static Colour CreateBlack()  => new Colour(0,   0,   0);
    public static Colour CreateBlue()   => new Colour(0,   0,   255);
    public static Colour CreateGreen()  => new Colour(0,   128, 0);
    public static Colour CreateOrange() => new Colour(255, 165, 0);
    public static Colour CreatePurple() => new Colour(128, 0,   128);
    public static Colour CreateRed()    => new Colour(255, 0,   0);

    public static Colour CreateWhite()  => new Colour(255, 255, 255);
    public static Colour CreateYellow() => new Colour(255, 255, 0);

    public string DisplayRGBValue() => $"({Red},{Green},{Blue})";
}