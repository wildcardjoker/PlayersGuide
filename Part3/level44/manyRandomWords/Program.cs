﻿while (true)
{
    Console.Write("Please enter a word to generate: ");
    var requestedWord = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(requestedWord))
    {
        GenerateWordAndDisplayAttemptsAsync(requestedWord);
    }
}

async Task GenerateWordAndDisplayAttemptsAsync(string word)
{
    var startTime        = DateTime.Now;                      // We're better off using a StopWatch object, but the objective says use DateTime.Now ¯\_(ツ)_/¯
    var numberOfAttempts = await RandomlyRecreateAsync(word); // Assume for this project that the user always enters at least one character.
    var endTime          = DateTime.Now;
    var taskTime         = endTime - startTime;
    Console.WriteLine(
        $"\nCreating the word {word} took {numberOfAttempts} attempts, and took {taskTime.Days}d, {taskTime.Hours}h, {taskTime.Minutes}m, {taskTime.Seconds}s, {taskTime.Milliseconds}ms");
}

static int RandomlyRecreate(string word)
{
    var  attempts = 0;
    var  length   = word.Length;
    var  random   = new Random();
    bool success;
    do
    {
        attempts++;
        var generatedWord = "";
        for (var i = 0; i < length; i++)
        {
            generatedWord += (char) ('a' + random.Next(26));
        }

        success = generatedWord.Equals(word, StringComparison.CurrentCultureIgnoreCase);
    }
    while (!success);

    return attempts;
}

async Task<int> RandomlyRecreateAsync(string word)
{
    return await Task.Run(() => RandomlyRecreate(word)).ConfigureAwait(false);
}