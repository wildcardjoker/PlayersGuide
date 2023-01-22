# The Thing Namer 3000

As you walk through the city of Commenton, admiring its forward-slash-based architectural buildings, a young man approaches you in a panic.

"I dropped my Thing Namer 3000 and broke it. I think it's mostly working, but all my variable names got reset! I don't understand what they do!"

He shows you the following program:

    Console.WriteLine("What kind of thing are we talking about?");
    string a = Console.ReadLine();
    Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
    string b = Console.ReadLine();
    string c = "of Doom";
    string d = "3000";
    Console.WriteLine("The " + b + " " + a + " of " + c + " " + d + "!");

"You gotta help me figure it out!"

## Objectives
- Rebuild the program above on your computer.
- Add comments near each of the four variables that describe what they store. You must use at least one of each comment type (`//` and `/*`)
- Find the bug in the text displayed and fix it.
- Answer this question: Aside from comments, what else could you do to make this code more understandable?
