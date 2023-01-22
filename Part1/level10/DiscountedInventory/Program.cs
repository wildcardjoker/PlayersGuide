// Let's create variables for the prices
// While the actual value of the halved costs isn't related to the sample, we'll make the costs a decimal value for the sake of
// completeness

var ropeCost              = 10m;
var torchCost             = 15m;
var climbingEquipmentCost = 25m;
var cleanWaterCost        = 1m;
var macheteCost           = 20m;
var canoeCost             = 200m;
var foodSuppliesCost      = 1m;

// Create a variable for the hero's name.
// Replace this value with your own name.
// This should be a constant, but they haven't been covered in the book yet.
var heroName = "wildcardjoker";

// Show the price list
Console.Title = "Discounted Inventory";
Console.WriteLine("Discounted Inventory");
Console.WriteLine("\nThe following items are available:");
Console.WriteLine();
Console.WriteLine("1: Rope:               10 gold");
Console.WriteLine("2: Torches:            15 gold");
Console.WriteLine("3: Climbing Equipment: 25 gold");
Console.WriteLine("4: Clean Water:        1 gold");
Console.WriteLine("5: Machete:            20 gold");
Console.WriteLine("6: Canoe:              200 gold");
Console.WriteLine("7: Food Supplies:      1 gold");
Console.Write("\nWhat number do you want to see the price of? ");
var choice = Convert.ToInt32(Console.ReadLine());

// Ask for the user's name
Console.Write("What is your name, adventurer? ");
var adventurerName = Console.ReadLine();

// Create variables for the item and cost
var     selectedItem     = "";
decimal selectedItemCost = 0;

// Locate the desired item
// We'll use a standard switch here - the Buying Inventory sample used an expression switch.
switch (choice)
{
    case 1:
        selectedItem     = "Rope";
        selectedItemCost = ropeCost;
        break;
    case 2:
        selectedItem     = "Torches";
        selectedItemCost = torchCost;
        break;
    case 3:
        selectedItem     = "ClimbingEquipment";
        selectedItemCost = climbingEquipmentCost;
        break;
    case 4:
        selectedItem     = "Clean Water";
        selectedItemCost = cleanWaterCost;
        break;
    case 5:
        selectedItem     = "Machetes";
        selectedItemCost = macheteCost;
        break;
    case 6:
        selectedItem     = "Canoes";
        selectedItemCost = canoeCost;
        break;
    case 7:
        selectedItem     = "Food Supplies";
        selectedItemCost = foodSuppliesCost;
        break;
}

// Check that a valid number has been entered.
if (choice < 1 || choice > 7)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Sorry, we don't stock that particular item.");

    // We should add a return statement here - that would eliminate the else block.
    // However, the book hasn't mentioned it yet, so we'll stick with the if/else clause.
}
else
{
    // If the hero is buying, divide the cost in half
    // We should use adventurerName.Equals(heroName) here, but again, the book hasn't covered it yet
    if (adventurerName == heroName)
    {
        selectedItemCost /= 2;
    }

    // Set up the 'cost' word here
    string costWord;
    if (choice == 1 || choice == 3 || choice == 4)
    {
        costWord = "costs";
    }
    else
    {
        costWord = "cost";
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{selectedItem} {costWord} {selectedItemCost} gold");
}