Console.Write("Please enter a word to generate: ");
var requestedWord    = Console.ReadLine();
var startTime        = DateTime.Now;                                // We're better off using a StopWatch object, but the objective says use DateTime.Now ¯\_(ツ)_/¯
var numberOfAttempts = await RandomlyRecreateAsync(requestedWord!); // Assume for this project that the user always enters at least one character.

var endTime  = DateTime.Now;
var taskTime = endTime - startTime;
Console.WriteLine($"It took {numberOfAttempts} attempts, and took {taskTime.Days}d, {taskTime.Hours}h, {taskTime.Minutes}m, {taskTime.Seconds}s");
return;

async Task<int> RandomlyRecreateAsync(string s)
{
    return await Task.Run(() => RandomlyRecreate(requestedWord)).ConfigureAwait(false);
}

static int RandomlyRecreate(string? word) => 1;