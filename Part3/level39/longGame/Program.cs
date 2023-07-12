const string title = "The Long Game";
Console.Title = title;
Console.WriteLine(title);

var     score    = 0;
string? username = null;

while (string.IsNullOrWhiteSpace(username))
{
    Console.Write("Please enter your username: ");
    username = Console.ReadLine();
}

while (Console.ReadKey().Key != ConsoleKey.Enter)
{
    score++;
    Console.WriteLine(score);
}

// User pressed the ENTER key - save the score to a file.

// Find the Common AppData directory, and add "playersGuide\longGame" to that path. We'll use that location to store our scores.
var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "playersGuide", "longGame");

// Ensure that the directory is created, otherwise a DirectoryNotFound exception is thrown.
Directory.CreateDirectory(path);

// Generate full path to file name.
var fileName = Path.Combine(path, $"{username}.txt");

// Save the score.
File.WriteAllText(fileName, score.ToString());