#region Using Directives
using ColouredConsoleLibrary;
#endregion

var name = ColouredConsole.Prompt("What is your name");
ColouredConsole.WriteLine($"Hello {name}", ConsoleColor.Green);