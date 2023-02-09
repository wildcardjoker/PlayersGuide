// Create a new pack.

Console.Title = "Packing Inventory";
var maxItems  = Convert.ToInt32(AskForNumberInRange("How many items can your pack hold", 1, 20));
var maxWeight = AskForNumberInRange("What is the maximum weight", 10, 100);
var maxVolume = AskForNumberInRange("What is the maximum volume", 10, 100);
var pack      = new Pack(maxItems, maxWeight, maxVolume);

float AskForNumber(string text)
{
    Console.Write($"{text}? "); // Add a space to the end of the question
    return Convert.ToSingle(Console.ReadLine());
}

float AskForNumberInRange(string text, int min, int max)
{
    float number;
    do
    {
        number = AskForNumber(text);
    }
    while (number < min || number > max);

    return number;
}

public class InventoryItem
{
    #region Constructors
    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
    #endregion

    #region Properties
    public float Volume {get;}
    public float Weight {get;}
    #endregion
}

public class Arrow : InventoryItem
{
    #region Constructors
    public Arrow() : base(0.1f, 0.05f) {}
    #endregion
}

public class Bow : InventoryItem
{
    #region Constructors
    public Bow() : base(1, 4) {}
    #endregion
}

public class Rope : InventoryItem
{
    #region Constructors
    public Rope() : base(1, 1.5f) {}
    #endregion
}

public class Water : InventoryItem
{
    #region Constructors
    public Water() : base(2, 3) {}
    #endregion
}

public class FoodRation : InventoryItem
{
    #region Constructors
    public FoodRation() : base(1, 0.5f) {}
    #endregion
}

public class Sword : InventoryItem
{
    #region Constructors
    public Sword() : base(5, 3) {}
    #endregion
}

public class Pack
{
    #region Constructors
    public Pack(int maxItems, float maxWeight, float maxVolume)
    {
        InventoryItems = new InventoryItem[maxItems];
        MaxItems       = maxItems;
        MaxWeight      = maxWeight;
        MaxVolume      = maxVolume;
    }
    #endregion

    #region Properties
    public int CurrentItemCount {get; private set;}

    public float           CurrentVolume  {get; private set;}
    public float           CurrentWeight  {get; private set;}
    public InventoryItem[] InventoryItems {get;}
    public int             MaxItems       {get;}
    public float           MaxVolume      {get;}
    public float           MaxWeight      {get;}
    #endregion

    public bool Add(InventoryItem item)
    {
        // We should use Lists and Linq here, but neither have been introduced, so we'll do it the manual way
        if (CurrentItemCount == MaxItems || item.Volume + CurrentVolume > MaxVolume || item.Weight + CurrentWeight > MaxWeight)
        {
            return false;
        }

        InventoryItems[CurrentItemCount - 1] = item;
        CurrentItemCount++;
        CurrentVolume += item.Volume;
        CurrentWeight += item.Weight;
        return true;
    }
}