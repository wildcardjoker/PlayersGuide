// We'll use the Triangle Farmer program from Level 7. I've removed the comments from the previous program to concentrate on the new
// objectives.

Console.Title = "P-Thag's Triangle Area Calculator";
Console.WriteLine("P-Thag doesn't farm triangles with a base or height larger than 100 units");
var triangleBase   = AskForNumberInRange("What is the base of the triangle",   1, 100);
var triangleHeight = AskForNumberInRange("What is the height of the triangle", 1, 100);

// Calculate the area.
var area = triangleBase * triangleHeight / 2;
Console.WriteLine($"The area of your triangle is {area} units");

int AskForNumber(string text)
{
    Console.Write($"{text}? "); // Add a space to the end of the question
    return Convert.ToInt32(Console.ReadLine());
}

int AskForNumberInRange(string text, int min, int max)
{
    int number;
    do
    {
        number = AskForNumber(text);
    }
    while (number < min || number > max);

    return number;
}