﻿Console.WriteLine("What kind of thing are we talking about?");

// a = The kind of thing
var a = Console.ReadLine();
Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
/* b = The thing's description */
var b = Console.ReadLine();
var c = "of Doom"; // Kind of obvious. Besides, this should be a constant
var d = "3000";    // Also obvious. Again, should be a constant. Or even better, an assembly version, or a Setting, or some other easily updateable property.

// Anyway, on to the bug fixing
// The original line includes the string " of ", then appends "of Doom", making the output "The {b} {a} of of Doom!"
// Let's remove the "of"
Console.WriteLine("The " + b + " " + a + " " + c + " " + d + "!");

// Answer this question: Aside from comments, what else could you do to make this code more understandable?
/*
 * So many things...
 * First, replace the variable names with something more descriptive.
 * a => thing
 * b => description
 * c => ofDoom
 * d => version
 *
 * Secondly, let's make c and d constants (OK, the book hasn't gotten there yet. I get it)
 *
 * Third, replace that godawful concatenation with string interpolation. Again, the book hasn't raised this issue,
 * and we've just gone through a chapter about writing comments, so I'll let it slide. But that line is just begging to be
 * written as
 * Console.WriteLine($"The {b} {a} {c} {d}!");
 *
 * Once you update the variable names, it's even better:
 * Console.WriteLine($"The {description} {thing} {ofDoom} {version}!");
 */