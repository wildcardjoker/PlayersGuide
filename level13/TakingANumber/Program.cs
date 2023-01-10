/* Taking a Number
 *
 * Many previous tasks have required getting a number from a user. To save time writing this code repeatedly, you have decided to make a
 * method to do this common task.
 *
 * Objectives:
 * Make a method with the signature int AskForNumber(string text). Display the text parameter in the console window, get a response
 * from the user, convert it to an int, and return it. This might look like this: int results = AskForNumber("What is the airspeed
 * velocity of an unladen swallow?");
 * Make a method with the signature int AskForNumberInRange(string text, int min, int max). Only return if the entered number is between
 * the min and max values. Otherwise, ask again.
 * Place these methods in at least one of your previous programs to improve it.
 */

// We'll use the Triangle Farmer program from Level 7. I've removed the comments from the previous program to concentrate on the new
// objectives.

Console.Title = "P-Thag's Triangle Area Calculator";
Console.WriteLine("Thag doesn't farm triangles with a base or height larger than 100 units");
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