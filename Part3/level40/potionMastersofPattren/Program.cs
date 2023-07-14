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
if (choice == ConsoleKey.C)
{
    Console.WriteLine($"\n\nYou are satisfied with the results of your alchemy, and label your vial: \"{potion.Humanize()}\"");
}

var nextIngredient = choice switch
{
    ConsoleKey.D1 => Ingredient.Stardust,
    ConsoleKey.D2 => Ingredient.SnakeVenom,
    ConsoleKey.D3 => Ingredient.DragonBreath,
    ConsoleKey.D4 => Ingredient.ShadowGlass,
    ConsoleKey.D5 => Ingredient.EyeShine,
    _             => Ingredient.Water
};

Console.WriteLine($"\nYou add {nextIngredient.Humanize()} to your vial of {potion.Humanize()}.");