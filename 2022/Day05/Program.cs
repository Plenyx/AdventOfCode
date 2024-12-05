using SharedLibs;
using System.Text.RegularExpressions;

var input = Shared.LoadFromFileAsSpan("input.txt");

Shared.StartExecutionTimer();

var numberCountRegex = new Regex(@"\d+");
var characterRegex = new Regex(@"(?:\[(\w)\])|(?: ?(   ) ?)");
var moveCommandRegex = new Regex(@"move (\d+) from (\d+) to (\d+)");

var stacks1 = new List<List<char>>();
var stacks2 = new List<List<char>>();
var stacksSetup = false;
var lineIndex = -1;

foreach (var line in input)
{
    if (!stacksSetup)
    {
        lineIndex++;
        var matchesOnLine = numberCountRegex.Matches(line);
        if (matchesOnLine.Count > 0)
        {
            stacksSetup = true;
            var matchCollection = new List<MatchCollection>();
            for (var i = lineIndex - 1; i >= 0; i--)
            {
                matchCollection.Add(characterRegex.Matches(input[i]));
            }
            for (var i = 0; i < matchesOnLine.Count; i++)
            {
                var newList = new List<char>();
                for (var j = 0; j < lineIndex; j++)
                {
                    if (string.IsNullOrWhiteSpace(matchCollection[j][i].Groups[1].Value))
                    {
                        continue;
                    }
                    newList.Add(matchCollection[j][i].Groups[1].Value[0]);
                }
                stacks1.Add(newList);
                stacks2.Add(new List<char>(newList));
            }
        }
        continue;
    }
    var moveCommandMatch = moveCommandRegex.Match(line);
    if (!moveCommandMatch.Success)
    {
        continue;
    }
    var howMany = int.Parse(moveCommandMatch.Groups[1].ValueSpan);
    var from = int.Parse(moveCommandMatch.Groups[2].ValueSpan);
    var to = int.Parse(moveCommandMatch.Groups[3].ValueSpan);
    stacks2[to - 1].AddRange(stacks2[from - 1].TakeLast(howMany));
    for (var i = 0; i < howMany; i++)
    {
        var lastChar = stacks1[from - 1][^1];
        stacks1[from - 1].RemoveAt(stacks1[from - 1].Count - 1);
        stacks2[from - 1].RemoveAt(stacks2[from - 1].Count - 1);
        stacks1[to - 1].Add(lastChar);
    }
}

Console.WriteLine($"Solution for part 1: {string.Join("", stacks1.Select(x => x.LastOrDefault()))}");
Console.WriteLine($"Solution for part 2: {string.Join("", stacks2.Select(x => x.LastOrDefault()))}");

Shared.StopAndWriteExecutionTimer();

Console.ReadLine();
