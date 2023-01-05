/*
 * The Dominion of Kings
 *
 * Three kings, Melik, Casik, and Balik, are sitting around a table, debating who has the greatest kingdom among them. Each king
 * rules and assortment of provinces, duchies, and estates. Collectively, they agree to a point system that helps them judge whose
 * kingdom is greatest: Every estate is worth 1 point, every duchy is worth 3 points, and every province is worth 6 points. They
 * just need a program that will allow them to enter their current holdings and compute a point total.
 *
 * Objectives:
 *
 * Create a program that allows users to enter how many provinces, duchies, and estates they have.
 * Add up the user's total score, giving 1 point per estate, 3 per duchy, and 6 per province.
 * Display the point total to the user.
 */

var estatePoints   = 1;
var duchyPoints    = 3;
var provincePoints = 6;

Console.WriteLine("The Dominion of Kings");
Console.WriteLine("How many provinces does the king have?");
var provinces = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("How many duchies does the king have?");
var duchies = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("How many estates does the king have?");
var estates = Convert.ToInt32(Console.ReadLine());

// Multiply each land parcel by the number of points associated.
// Given that the book demonstrated compound assignments right before this challenge, let's use them
estates   *= estatePoints; // Technically, we could ignore this line as multiplying by 1 isn't going to change the outcome.
duchies   *= duchyPoints;
provinces *= provincePoints;

Console.WriteLine($"Estate   points: {estates}");
Console.WriteLine($"Duchy    points: {duchies}");
Console.WriteLine($"Province points: {provinces}");
Console.WriteLine($"Total    points: {estates + duchies + provinces}");