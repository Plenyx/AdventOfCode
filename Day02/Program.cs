using SharedLibs;

// Part 1
// A | X = Rock = 1
// B | Y = Paper = 2
// C | Z = Scissors = 3

var input = Shared.LoadFromFileAsSpan("input.txt");

Shared.StartExecutionTimer();

var points = 0;

foreach (ReadOnlySpan<char> line in input)
{
    if (line.Length < 3) continue;
    var opponent = line[0] - 64;
    var me = line[2] - 87;
    var result = me - opponent;
    if (Math.Abs(result) == 0)
    {
        points += 3 + me;
        continue;
    }
    points += (((Math.Abs(result) == 2 && result < 0) || (Math.Abs(result) == 1 && result > 0)) ? 6 : 0) + me;
}

Console.WriteLine($"The solution for part 1 is: {points} points");

// Part 2
// A = Rock = 1
// B = Paper = 2
// C = Scissors = 3
// X = Lose = 1
// Y = Draw = 2
// Z = Win = 3

points = 0;

foreach (ReadOnlySpan<char> line in input)
{
    if (line.Length < 3) continue;
    var opponent = line[0] - 64;
    var me = line[2] - 87;
    if (me == 2)
    {
        points += 3 + opponent;
        continue;
    }
    if (me == 1)
    {
        points += (opponent == 1 ? 3 : (opponent == 2) ? 1 : 2);
        continue;
    }
    points += 6 + (opponent == 1 ? 2 : (opponent == 2) ? 3 : 1);
}

Console.WriteLine($"The solution for part 2 is: {points} points");

Shared.StopAndWriteExecutionTimer();

Console.ReadLine();
