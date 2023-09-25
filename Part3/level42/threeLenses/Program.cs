#region Using Directives
using System.Diagnostics;
#endregion

var input = new[] {1, 9, 2, 8, 3, 7, 4, 6, 5};

SolveWithProceduralCode(input);
SolveWithKeywordQuery(input);

return;

void SolveWithKeywordQuery(IEnumerable<int> data)
{
    Console.WriteLine("Solving using keyword query");
    var sw = Stopwatch.StartNew();

    // Find all even numbers.
    var output = (from i in data where IsEven(i) select i).ToList(); // Avoid multiple enumeration
    ShowOutput("Even numbers", output);

    // Sort the numbers
    output.Sort();
    ShowOutput("Sorted numbers", output);

    // Double each number
    output = (from i in output select i * 2).ToList();
    ShowOutput("Doubled numbers", output);
    sw.Stop();
    Console.WriteLine($"Time: {sw.Elapsed.TotalMilliseconds} ms");
}

void SolveWithProceduralCode(IEnumerable<int> data)
{
    Console.WriteLine("Solving using procedural code");
    var sw     = Stopwatch.StartNew();
    var output = new List<int>();

    // Find all even numbers.
    // ReSharper disable once LoopCanBeConvertedToQuery
    foreach (var i in data)
    {
        if (IsEven(i))
        {
            output.Add(i);
        }
    }

    ShowOutput("Even numbers", output);

    // Sort the numbers
    output.Sort();
    ShowOutput("Sorted numbers", output);

    // Double each number
    for (var i = 0; i < output.Count; i++)
    {
        output[i] *= 2;
    }

    ShowOutput("Doubled numbers", output);
    sw.Stop();
    Console.WriteLine($"Time: {sw.Elapsed.TotalMilliseconds} ms");
}

void ShowOutput(string step, IEnumerable<int> data) => Console.WriteLine($"{step}: {string.Join(", ", data)}");
bool IsEven(int        i) => i % 2 == 0;