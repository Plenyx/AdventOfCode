using Day11;
using SharedLibs;

var input = Shared.LoadFromFileAsSpan("input.txt");

var listOfMonkeys = Monkey.All;

var id = 0;
var items = new List<ulong>();
var testDivisableBy = 0uL;
var operation = string.Empty;
var testTrueId = 0;
var testFalseId = 0;

Shared.StartExecutionTimer();

foreach (ReadOnlySpan<char> line in input)
{
    if (line.Length == 0)
    {
        listOfMonkeys.Add(new Monkey()
        {
            Id = id,
            Items = new List<ulong>(items),
            ItemsPart2 = new List<ulong>(items),
            Operation = operation,
            TestDivisableBy = testDivisableBy,
            TestTrueId = testTrueId,
            TestFalseId = testFalseId,
        });
        items.Clear();
        continue;
    }

    if (line.StartsWith("Monkey"))
    {
        id = int.Parse(line[7..^1]);
        continue;
    }

    if (line.StartsWith("  Starting items"))
    {
        ReadOnlySpan<char> itemsSpan = line[18..];
        int commaIndex = itemsSpan.IndexOf(',');
        if (commaIndex == -1)
        {
            items.Add(ulong.Parse(itemsSpan));
            continue;
        }
        while (commaIndex > 0)
        {
            ReadOnlySpan<char> numberItem = itemsSpan[..commaIndex];
            items.Add(ulong.Parse(numberItem));
            commaIndex = itemsSpan.IndexOf(',');
            itemsSpan = itemsSpan[(commaIndex+2)..];
        }
    }

    if (line.StartsWith("  Operation"))
    {
        operation = line[19..].ToString();
        continue;
    }

    if (line.StartsWith("  Test"))
    {
        testDivisableBy = ulong.Parse(line[21..]);
        continue;
    }

    if (line.StartsWith("    If true"))
    {
        testTrueId = int.Parse(line[29..]);
        continue;
    }

    if (line.StartsWith("    If false"))
    {
        testFalseId = int.Parse(line[30..]);
        continue;
    }
}

listOfMonkeys.Add(new Monkey()
{
    Id = id,
    Items = new List<ulong>(items),
    ItemsPart2 = new List<ulong>(items),
    Operation = operation,
    TestDivisableBy = testDivisableBy,
    TestTrueId = testTrueId,
    TestFalseId = testFalseId,
});

// part 1
for (int i = 0; i < 20; i++)
{
    foreach (Monkey monkey in listOfMonkeys)
    {
        monkey.ThrowItems();
    }
}

Console.WriteLine($"Solution for part 1: {listOfMonkeys.OrderByDescending(x => x.InspectedItems).Take(2).Select(x => x.InspectedItems).Aggregate((x, y) => x * y)}");

foreach (Monkey monkey in listOfMonkeys)
{
    monkey.InspectedItems = 0;
}

// part 2
var allDividedBy = 1uL;
foreach (Monkey monkey in listOfMonkeys.AsSpan())
{
    allDividedBy *= monkey.TestDivisableBy;
}
for (int i = 0; i < 10000; i++)
{
    foreach (Monkey monkey in listOfMonkeys)
    {
        monkey.ThrowItemsPart2(allDividedBy);
    }
}

var top2 = listOfMonkeys.OrderByDescending(x => x.InspectedItems).Take(2).Select(x => x.InspectedItems).ToArray();
Console.WriteLine($"Solution for part 2: {top2[0] * top2[1]}");

Shared.StopAndWriteExecutionTimer();

Console.ReadLine();
