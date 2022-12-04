using SharedLibs;

var input = Shared.LoadFromFileAsSpan("input.txt");

Shared.StartExecutionTimer();

var fullyContained = 0;
var anyContained = 0;

foreach (ReadOnlySpan<char> line in input)
{
    if (line.Length < 7) continue;
    var commaLocation = line.IndexOf(',');
    var first = line[..commaLocation];
    var firstDashLocation = first.IndexOf('-');
    var firstLower = int.Parse(first[..firstDashLocation]);
    var firstUpper = int.Parse(first[(firstDashLocation + 1)..]);
    var second = line[(commaLocation + 1)..];
    var secondDashLocation = second.IndexOf('-');
    var secondLower = int.Parse(second[..secondDashLocation]);
    var secondUpper = int.Parse(second[(secondDashLocation + 1)..]);
    if (((firstLower <= secondLower) && (firstUpper >= secondUpper))
        || ((secondLower <= firstLower) && (secondUpper >= firstUpper)))
    {
        fullyContained++;
    }
    var firstRange = Enumerable.Range(firstLower, firstUpper - firstLower + 1).ToArray().AsSpan();
    var secondRange = Enumerable.Range(secondLower, secondUpper - secondLower + 1).ToArray().AsSpan();
    foreach (var firstNumber in firstRange)
    {
        if (secondRange.Contains(firstNumber))
        {
            anyContained++;
            break;
        }
    }
}

Console.WriteLine($"Solution for part 1: {fullyContained} fully contained");
Console.WriteLine($"Solution for part 2: {anyContained} any contained");

Shared.StopAndWriteExecutionTimer();

Console.ReadLine();
