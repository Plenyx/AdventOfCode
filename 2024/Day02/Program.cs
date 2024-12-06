using SharedLibs;

var input = Shared.LoadFromFileAsSpan("input.txt");

var result = 0;
var result2 = 0;

Shared.StartExecutionTimer();

int areNumbersSafe(List<string> items)
{
    var previousPreviousNumber = int.Parse(items[0]);
    var previousNumber = int.Parse(items[1]);
    var startDiff = Math.Abs(previousPreviousNumber - previousNumber);
    if (startDiff < 1 || startDiff > 3)
    {
        return 0;
    }
    for (int i = 2; i < items.Count; i++)
    {
        var number = int.Parse(items[i]);
        var diff = Math.Abs(number - previousNumber);
        if (diff < 1 || diff > 3)
        {
            return 0;
        }
        if (previousPreviousNumber > previousNumber)
        {
            if (previousNumber < number)
            {
                return 0;
            }
        }
        else if (previousPreviousNumber < previousNumber)
        {
            if (previousNumber > number)
            {
                return 0;
            }
        }
        previousPreviousNumber = previousNumber;
        previousNumber = number;
    }
    return 1;
}

int areNumbersSafeDamp(List<string> items)
{
    if (areNumbersSafe([..items]) == 1)
    {
        return 1;
    }
    for (int i = 0; i < items.Count; i++)
    {
        List<string> newItems = new(items);
        newItems.RemoveAt(i);
        if (areNumbersSafe([..newItems]) == 1)
        {
            return 1;
        }
    }
    return 0;
}

foreach (var item in input)
{
    var items = item.Split(" ").ToList();
    result += areNumbersSafe(items);
    result2 += areNumbersSafeDamp(items);
}


Console.WriteLine($"Solution for part 1: {result}");
Console.WriteLine($"Solution for part 2: {result2}");

Shared.StopAndWriteExecutionTimer();
