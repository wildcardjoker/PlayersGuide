#region Using Directives
using Humanizer;
using potionMastersOfPattren;
#endregion

var potion = Potion.Water;
Console.WriteLine($"You have a vial of {potion}");
Console.WriteLine("You can add an ingredient, or complete the potion.");
foreach (var ingredient in Enum.GetValues(typeof(Ingredient)))
{
    Console.WriteLine($"{(int) ingredient}: {((Ingredient) ingredient).Humanize()}"); // Using Humanizer to split Enum names into words
}

Console.WriteLine("C: Complete the potion as-is\n");
Console.Write("Please enter your choice: ");
var choice = Console.ReadKey().Key;
while (choice != ConsoleKey.C)
{
    var nextIngredient = choice switch
    {
        ConsoleKey.D0 or ConsoleKey.NumPad0 => Ingredient.DragonBreath,
        ConsoleKey.D1 or ConsoleKey.NumPad1 => Ingredient.EyeShine,
        ConsoleKey.D2 or ConsoleKey.NumPad2 => Ingredient.ShadowGlass,
        ConsoleKey.D3 or ConsoleKey.NumPad3 => Ingredient.SnakeVenom,
        ConsoleKey.D4 or ConsoleKey.NumPad4 => Ingredient.Stardust,
        _                                   => Ingredient.Water
    };

    Console.WriteLine($"\nYou add {nextIngredient.Humanize()} to your vial of {potion.Humanize()}.");

    potion = (potion, nextIngredient) switch
    {
        (Potion.Water, Ingredient.Stardust)               => Potion.Elixir,
        (Potion.Elixir, Ingredient.SnakeVenom)            => Potion.PoisionPotion,
        (Potion.Elixir, Ingredient.DragonBreath)          => Potion.FlyingPotion,
        (Potion.Elixir, Ingredient.ShadowGlass)           => Potion.InvisibilityPotion,
        (Potion.Elixir, Ingredient.EyeShine)              => Potion.NightSightPotion,
        (Potion.NightSightPotion, Ingredient.ShadowGlass) => Potion.CloudyBrew,
        (Potion.InvisibilityPotion, Ingredient.EyeShine)  => Potion.CloudyBrew,
        (Potion.CloudyBrew, Ingredient.Stardust)          => Potion.WraithPotion,
        _                                                 => Potion.Ruined
    };
    var message = potion switch
    {
        Potion.CloudyBrew         => "turns a cloudy grey",
        Potion.Elixir             => "becomes a milky white",
        Potion.FlyingPotion       => "shines like gold",
        Potion.InvisibilityPotion => "flashes brightly, then becomes clear once again",
        Potion.NightSightPotion   => "slowly thickens and becomes a silvery colour",
        Potion.PoisionPotion      => "emits a sweet smell and becomes a lurid green",
        Potion.WraithPotion       => "becomes as black as night. You see a ghostly image appear above the vial",
        _                         => "explodes with a loud bang!"
    };
    var result = potion == Potion.Ruined
                     ? "Your potion has been ruined. Sighing, you reach for another vial of water, and try again."
                     : $"You have created a {potion.Humanize()}!";
    Console.WriteLine($"The potion {message}. {result}");
    potion = potion == Potion.Ruined ? Potion.Water : potion;
    choice = Console.ReadKey().Key;
}

Console.WriteLine($"\n\nYou are satisfied with the results of your alchemy, and label your vial: \"{potion.Humanize()}\"");