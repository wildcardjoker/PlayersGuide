#region Using Directives
using System.Dynamic;
#endregion

var     robotNumber = 0;
dynamic robot       = new ExpandoObject();
robot.Id = ++robotNumber;
Console.WriteLine($"You are producing robot #{robot.Id}");
if (GetYesNoResponse("Do you want to name this robot") == ConsoleKey.Y)
{
    var name = GetValueResponse("What is its name");
    if (!string.IsNullOrWhiteSpace(name))
    {
        robot.Name = name;
    }
}

Console.WriteLine();
foreach (var property in (IDictionary<string, object>) robot)
{
    Console.WriteLine($"{property.Key}: {property.Value}");
}

return;

ConsoleKey GetYesNoResponse(string question)
{
    Console.Write(WriteQuestion(question));
    return Console.ReadKey().Key;
}

string? GetValueResponse(string question)
{
    Console.Write(WriteQuestion(question));
    return Console.ReadLine();
}

string WriteQuestion(string s) => $"{s}? ";