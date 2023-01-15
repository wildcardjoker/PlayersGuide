// Create a tuple to hold the user's choices.

(SoupType SoupType, Ingredient Ingredient, Seasoning Seasoning) food;
DisplaySoupMenu();
food.SoupType = (SoupType) AskForNumberInRange("Which food would you like", 0, (int) SoupType.Gumbo);
DisplayIngredientMenu();
food.Ingredient = (Ingredient) AskForNumberInRange("Which ingredient would you like", 0, (int) Ingredient.Potato);
DisplaySeasoningMenu();
food.Seasoning = (Seasoning) AskForNumberInRange("Which seasoning would you like", 0, (int) Seasoning.Sweet);

// Display the created food.
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"\n{food.Seasoning} {food.Ingredient} {food.SoupType}");
Console.ResetColor();

void DisplaySoupMenu()
{
    Console.WriteLine("\nThe following foods are available:");

    // Ideally, you'd loop through the enum values but the book hasn't covered that yet.
    // We'll display them individually.
    Console.WriteLine($"{(int) SoupType.Soup}: {SoupType.Soup}");
    Console.WriteLine($"{(int) SoupType.Stew}: {SoupType.Stew}");
    Console.WriteLine($"{(int) SoupType.Gumbo}: {SoupType.Gumbo}");
}

void DisplayIngredientMenu()
{
    Console.WriteLine("\nThe following ingredients are available:");
    Console.WriteLine($"{(int) Ingredient.Mushroom}: {Ingredient.Mushroom}");
    Console.WriteLine($"{(int) Ingredient.Chicken}: {Ingredient.Chicken}");
    Console.WriteLine($"{(int) Ingredient.Carrot}: {Ingredient.Carrot}");
    Console.WriteLine($"{(int) Ingredient.Potato}: {Ingredient.Potato}");
}

void DisplaySeasoningMenu()
{
    Console.WriteLine("\nThe following seasonings are available:");
    Console.WriteLine($"{(int) Seasoning.Spicy}: {Seasoning.Spicy}");
    Console.WriteLine($"{(int) Seasoning.Salty}: {Seasoning.Salty}");
    Console.WriteLine($"{(int) Seasoning.Sweet}: {Seasoning.Sweet}");
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

internal enum SoupType
{
    Soup,
    Stew,
    Gumbo
}

internal enum Ingredient
{
    Mushroom,
    Chicken,
    Carrot,
    Potato
}

internal enum Seasoning
{
    Spicy,
    Salty,
    Sweet
}