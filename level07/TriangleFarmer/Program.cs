/*
 * The Triangle Farmer
 *
 * As you pass through the fields near Arithmetica City, you encounter P-Thag, a triangle farmer, scratching numbers in the dirt.
 *
 * "What is all of that writing for?" you ask.
 *
 * "I'm just trying to calculate the area of all of my triangles. They sell by their size. The bigger they are, the more they are
 * worth! But I have many triangles on my farm, and the math gets tricky, and I sometimes make mistakes. Taking a tiny triangle to
 * town thinking you're going to get 100 gold, only to be told it's only worth three, is not fun! If only I had a program that could
 * help me..."
 *
 * Suddenly, P-Thag looks at you with fresh eyes. "Wait just a moment. You have the look of a Programmer about you. Can you help me
 * write a program that will compute the areas for me, so I can quit worrying about math mistakes and get back to tending to my
 * triangles? The equation I'm using is this one here," he says, pointing to the formula, etched in a stone beside him:
 *
 *        base x height
 * Area = -------------
 *             2
 *
 * Objectives:
 *
 * Write a program that lets you input the triangle's base size and height.
 * Compute the area of a triangle by turning the above equation into code.
 * Write the result of the computation.
 */

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