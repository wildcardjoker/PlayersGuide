int?    intValue    = null;
double? doubleValue = null;
while (intValue == null && doubleValue == null)
{
    Console.Write("Please enter a number: ");
    var s = Console.ReadLine();
    if (int.TryParse(s, out var intResult))
    {
        intValue = intResult;
    }

    if (double.TryParse(s, out var doubleResult))
    {
        doubleValue = doubleResult;
    }
}

Console.WriteLine(intValue ?? doubleValue);