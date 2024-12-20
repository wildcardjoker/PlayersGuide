﻿const string title = "The Long Game";
Console.Title = title;
Console.WriteLine(title);

var     score    = 0;
string? username = null;

while (string.IsNullOrWhiteSpace(username))
{
    Console.Write("Please enter your username: ");
    username = Console.ReadLine();
}

var fileName = GetScorePath();

// Does this user have a score history?
if (File.Exists(fileName))
{
    _ = int.TryParse(File.ReadAllText(fileName), out score);
}

Console.Clear();
Console.WriteLine(title);
Console.WriteLine($"Begin typing.\n\nYour score: {score}");

while (Console.ReadKey(true).Key != ConsoleKey.Enter) // Capture keypresses but do not display the pressed key to the console. Break if ENTER key is pressed.
{
    score++;
    Console.SetCursorPosition(12, 3);
    Console.WriteLine(score);
}

// User pressed the ENTER key - save the score to a file.

// Save the score.
File.WriteAllText(fileName, score.ToString());
Console.WriteLine($"Your score has been saved to {fileName}");

string GetScorePath()
{
    // Find the Common AppData directory, and add "playersGuide\longGame" to that path. We'll use that location to store our scores.
    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "playersGuide", "longGame");

    // Ensure that the directory is created, otherwise a DirectoryNotFound exception is thrown.
    Directory.CreateDirectory(path);

    // Replace invalid file characters in username with _
    var userFileName = string.Join("_", username!.Split(Path.GetInvalidFileNameChars())); // Username will never be null here. Use ! to indicate non-null string.

    // Generate full path to file name.
    return Path.Combine(path, $"{userFileName}.txt");
}