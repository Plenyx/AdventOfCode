using SharedLibs;

var input = Shared.LoadFromFileAsSpan("input.txt");

Shared.StartExecutionTimer();

var currentElf = 0;

var elfs = new List<int>();

foreach (var line in input)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        elfs.Add(currentElf);
        currentElf = 0;
    }
    if (int.TryParse(line, out int parsedInt))
    {
        currentElf += parsedInt;
    }
}

if (currentElf > 0)
{
    elfs.Add(currentElf);
}

var top3 = elfs.OrderByDescending(x => x).Take(3).ToArray();

Console.WriteLine($"The solution for part 1 is: {top3[0]} calories");
Console.WriteLine($"The solution for part 2 is: {top3.Sum()} calories");

Shared.StopAndWriteExecutionTimer();

Console.ReadLine();
