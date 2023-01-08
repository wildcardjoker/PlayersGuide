/*
 * Buying Inventory
 *
 * It is time to resupply. A nearby outfitter shop has the supplies you need but it is so disorganised that they cannot sell things to
 * you. "Can't sell if i can't find the price list," Tortuga, the owner, tell you as he turns over and attempts to go back to sleep in
 * his reclining chair in the corner.
 *
 * There's a simple solution: use your programming powers to build something to report the prices of various pieces of equipment,
 * based on the user's selection:
 *
 * The following items are available:
 * 1 - Rope
 * 2 - Torches
 * 3 - Climbing Equipment
 * 4 - Clean Water
 * 5 - Machete
 * 6 - Canoe
 * 7 - Food Supplies
 * What number to you want to see the price of? 2
 * Torches cost 15 gold
 *
 * You search around the shop and find ledgers that show the following prices for these items:
 * Rope:               10 gold
 * Torches:            15 gold
 * Climbing Equipment: 25 gold
 * Clean Water:        1 gold
 * Machete:            20 gold
 * Canoe:              200 gold
 * Food Supplies:      1 gold
 *
 * Objectives:
 * Build a program that will show the menu illustrated above
 * Ask the user to enter a number from the menu
 * Using the information above, use a switch (either type) to show the item's cost.
 *
 * [The two switch types mentioned are the standard switch, and expression switch]
 */

Console.Title = "Buying Inventory";
Console.WriteLine("Buying Inventory");
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

// We'll use an expression switch here
// We should return an array or tuple of values (item, price) here, but for the sake of simplicity we'll return the full response.
var response = choice switch
{
    1 => "Rope costs 10 gold",
    2 => "Torches cost 15 gold",
    3 => "Climbing Equipment costs 25 gold",
    4 => "Clean Water costs 1 gold",
    5 => "Machetes cost 20 gold",
    6 => "Canoes cost 200 gold",
    7 => "Food Supplies cost 1 gold",
    _ => "Sorry, that item isn't on the list."
};

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(response);