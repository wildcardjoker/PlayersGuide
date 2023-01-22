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