#region Using Directives
using System.Dynamic;
#endregion

var robotNumber = 0;
while (true)
{
    dynamic robot = new ExpandoObject();
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

    if (GetYesNoResponse("Does this robot have a specific size") == ConsoleKey.Y)
    {
        var height = GetValueResponse("What is its height");
        if (!string.IsNullOrWhiteSpace(height))
        {
            robot.Height = height;
        }

        var width = GetValueResponse("What is its width");
        if (!string.IsNullOrWhiteSpace(width))
        {
            robot.Width = width;
        }
    }

    if (GetYesNoResponse("Does this robot need to be a specific colour") == ConsoleKey.Y)
    {
        var colour = GetValueResponse("What colour");
        if (!string.IsNullOrWhiteSpace(colour))
        {
            robot.Colour = colour;
        }
    }

    Console.WriteLine();
    foreach (var property in (IDictionary<string, object>) robot)
    {
        Console.WriteLine($"{property.Key}: {property.Value}");
    }
}

ConsoleKey GetYesNoResponse(string question)
{
    Console.Write(WriteQuestion(question));
    var response = Console.ReadKey().Key;
    Console.WriteLine();
    return response;
}

string? GetValueResponse(string question)
{
    Console.Write(WriteQuestion(question));
    return Console.ReadLine();
}

string WriteQuestion(string s) => $"{s}? ";