using SharedLibs;
using System.Text.RegularExpressions;

var input = Shared.LoadFromFileAsSpan("input.txt");

var redRegEx = new Regex(@"(\d+) red", RegexOptions.IgnoreCase | RegexOptions.Multiline);
var blueRegEx = new Regex(@"(\d+) blue", RegexOptions.IgnoreCase | RegexOptions.Multiline);
var greenRegEx = new Regex(@"(\d+) green", RegexOptions.IgnoreCase | RegexOptions.Multiline);

Shared.StartExecutionTimer();

var part1Result = 0;

foreach (var line in input)
{
    var gameSplit = line.Split(':');
    var gameId = int.Parse(gameSplit[0][5..]);
    var sets = gameSplit[1].Split(';');

    var failed = false;

    foreach (var set in sets)
    {
        var red = 12;
        var green = 13;
        var blue = 14;
        foreach (Match match in redRegEx.Matches(set))
        {
            red -= int.Parse(match.Groups[1].ValueSpan);
        }

        foreach (Match match in greenRegEx.Matches(set))
        {
            green -= int.Parse(match.Groups[1].ValueSpan);
        }

        foreach (Match match in blueRegEx.Matches(set))
        {
            blue -= int.Parse(match.Groups[1].ValueSpan);
        }
        if (red < 0 || green < 0 || blue < 0)
        {
            failed = true;
            break;
        }
    }
    if (!failed)
    {
        part1Result += gameId;
    }
}

Console.WriteLine($"Solution to part 1: {part1Result}");

var part2Result = 0;

foreach (var line in input)
{
    var red = 0;
    var green = 0;
    var blue = 0;

    foreach (Match match in redRegEx.Matches(line))
    {
        var redCount = int.Parse(match.Groups[1].ValueSpan);
        if (redCount > red)
        {
            red = redCount;
        }
    }

    foreach (Match match in greenRegEx.Matches(line))
    {
        var greenCount = int.Parse(match.Groups[1].ValueSpan);
        if (greenCount > green)
        {
            green = greenCount;
        }
    }

    foreach (Match match in blueRegEx.Matches(line))
    {
        var blueCount = int.Parse(match.Groups[1].ValueSpan);
        if (blueCount > blue)
        {
            blue = blueCount;
        }
    }

    part2Result += red * green * blue;
}

Console.WriteLine($"Solution to part 2: {part2Result}");

Shared.StopAndWriteExecutionTimer();

Console.ReadLine();
