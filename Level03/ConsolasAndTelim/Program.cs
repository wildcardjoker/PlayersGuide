// In the nearby city of Consolas, food is running short. Telim has a magic oven that can produce bread from thin air. He is willing to share, but Telim is an Excelian, and Excelians love paperwork; they demand it for all transactions - no exceptions.Telim will share his bread with the city if you can build a program that lets him enter the names of those receiving it. A sample run of this program looks like this:

// Bread is ready
// Who is the bread for?
// [user enters name]
// Noted: [name] got bread.

// Make a program that runs as shown above, including taking a name from the user.

Console.WriteLine("Bread is ready.");
Console.WriteLine("Who is the bread for?");
var name = Console.ReadLine();
Console.WriteLine($"Noted: {name} got bread.");

// Notes:
// No null check on [name] parameter
// Presumably, more than one person will receive this magic bread, so this code should be in a loop. I've left it very basic as per the book's request.
// The book specifies declaring/assigning variables on different lines, and using concatenation when writing the last line. I prefer to use var where possible, and string interpolation is more readable.