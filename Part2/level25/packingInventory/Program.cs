// InventoryItem class

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

// FoodRation class
// Sword class
// // Pack class