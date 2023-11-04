// Use Add() method with dynamic typing to add two values together

Console.WriteLine(Add(1,            1));
Console.WriteLine(Add(25.5,         25.5));
Console.WriteLine(Add("Hello",      " World"));
Console.WriteLine(Add(DateTime.Now, new TimeSpan(1, 0, 0)));
return;

static dynamic Add(dynamic a, dynamic b) => a + b;