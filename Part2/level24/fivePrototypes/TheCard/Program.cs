// Ideally, since we're dealing with enums, we'd use the Enum. methods to iterate through all possible values.
// Since that hasn't been covered yet, we'll use magic numbers to convert the counter to the required enum.
// RB's example used an array for Colour and Rank. Rather than update my code, I've decided to leave it as originally created. This gives users two viable examples.

for (var i = 0; i < 4; i++)
{
    var colour = (Colour) i;
    for (var j = 0; j < 14; j++)
    {
        var rank = (Rank) j;
        var card = new Card(colour, rank);
        Console.WriteLine($"{card.CardDescription}: {card.CardValueType}");
    }
}

// Answer this question: Why do you think we used a colour enumeration here but make a Colour class in the previous challenge?
// Teh colours are static, and will never change. The application as currently designed will not be required to create variations on these colours.

public class Card
{
    #region Constructors
    public Card(Colour colour, Rank rank)
    {
        CardColour = colour;
        CardRank   = rank;
    }
    #endregion

    #region Properties
    public Colour CardColour {get;}

    public string CardDescription => $"The {CardColour} {CardRank}";
    public Rank   CardRank        {get;}
    public string CardValueType   => IsNumberCard ? "Number card" : "Symbol Card";
    public bool   IsNumberCard    => (int) CardRank <= 9;
    public bool   IsSymbolCard    => (int) CardRank > 10;
    #endregion
}

public enum Colour
{
    Blue,
    Green,
    Red,
    Yellow
}

public enum Rank
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Currency,
    Percent,
    Caret,
    Ampersand
}