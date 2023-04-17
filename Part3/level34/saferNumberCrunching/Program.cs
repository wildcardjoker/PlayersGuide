string? s;
int? value=null;
while (value==null)
{
    Console.Write("Please enter a number: ");
    s = Console.ReadLine();
    if (int.TryParse(s,out int result))
    {
        value = result;
    }
}
Console.WriteLine(value);