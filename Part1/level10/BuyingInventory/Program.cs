﻿Console.Title = "Buying Inventory";
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