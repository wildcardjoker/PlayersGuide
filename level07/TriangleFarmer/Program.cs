// Finally, the var type has been introduced

Console.WriteLine("P-Thag's Triangle Area Calculator");

// We should use Console.Write() here so that you can enter your answer on the same line.
// As the book hasn't introduced it yet, we'll stick with good ol' Console.WriteLine()
Console.WriteLine("What is the base of the triangle?");

// The book hasn't introduced validation or error handling yet, so don't use non-numeric digits, or 0
// Bad things will happen!
var triangleBase = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("What is the height of the triangle?");
var triangleHeight = Convert.ToInt32(Console.ReadLine());

// Calculate the area.
var area = triangleBase * triangleHeight / 2;
Console.WriteLine($"The area of your triangle is {area} units");