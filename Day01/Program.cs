using SharedLibs;

var input = Shared.LoadFromFileAsSpan("input.txt");

Shared.StartExecutionTimer();

var previousNumber = int.MinValue;
var increments = -1;

foreach (ReadOnlySpan<char> line in input)
{
    var number = int.Parse(line);
    if (number > previousNumber)
    {
        increments++;
    }
    previousNumber = number;
}

Console.WriteLine($"Solution for part 1: {increments}");

previousNumber = int.MinValue;
int window1 = int.MinValue, window2 = int.MinValue;
increments = -1;
var status = 0;

foreach (ReadOnlySpan<char> line in input)
{
    status++;
    var number = int.Parse(line);
    if (status > 2)
    {
        if (window1 + window2 + number > previousNumber)
        {
            increments++;
        }
        previousNumber = window1 + window2 + number;
    }
    window1 = window2;
    window2 = number;
}

Console.WriteLine($"Solution for part 1: {increments}");

Shared.StopAndWriteExecutionTimer();

Console.ReadLine();
