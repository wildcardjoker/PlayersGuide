int?    intValue    = null;
double? doubleValue = null;
bool?   boolValue   = null;
while (intValue == null && doubleValue == null && boolValue == null)
{
    Console.Write("Please enter a number (whole or decimal), or true/false: ");
    var s = Console.ReadLine();
    if (int.TryParse(s, out var intResult))
    {
        intValue = intResult;
    }

    if (double.TryParse(s, out var doubleResult))
    {
        doubleValue = doubleResult;
    }

    if (bool.TryParse(s, out var boolResult))
    {
        boolValue = boolResult;
    }
}

Console.WriteLine(boolValue.HasValue ? boolValue : intValue ?? doubleValue);