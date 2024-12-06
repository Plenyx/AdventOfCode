using SharedLibs;

var input = Shared.LoadFromFileAsSpan("input.txt");

var list1 = new List<int>();
var list2 = new List<int>();

var result = 0;
var result2 = 0;

foreach (ReadOnlySpan<char> item in input)
{
    var firstSpace = item.IndexOf(" ", StringComparison.Ordinal);
    var lastSpace = item.LastIndexOf(" ", StringComparison.Ordinal);
    var firstNumber = item[..firstSpace];
    list1.Add(int.Parse(firstNumber));
    var secondNumber = item[(lastSpace + 1)..];
    list2.Add(int.Parse(secondNumber));
}

list1 = [.. list1.OrderBy(x => x)];
list2 = [.. list2.OrderBy(x => x)];

Shared.StartExecutionTimer();

for (int i = 0; i < list1.Count; i++)
{
    result += Math.Abs(list1[i] - list2[i]);
}

Console.WriteLine($"Solution for part 1: {result}");

for (int i = 0; i < list1.Count; i++)
{
    var number = list1[i];
    var times = list2.Where(x => x == number).Count();
    result2 += number * times;
}

Console.WriteLine($"Solution for part 2: {result2}");

Shared.StopAndWriteExecutionTimer();
