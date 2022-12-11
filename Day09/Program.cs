using Day09;
using SharedLibs;

var input = Shared.LoadFromFileAsSpan("input.txt");

Shared.StartExecutionTimer();

var startingPosition = new Vector2D { X = 0, Y = 0 };

var tailPart1Positions = new HashSet<Vector2D>() { startingPosition };
var tailPart2Positions = new HashSet<Vector2D>() { startingPosition };

var rope9 = new Rope() { Head = startingPosition, Tail = startingPosition };
var rope8 = new Rope() { Head = startingPosition, Tail = startingPosition, NextRope = rope9 };
var rope7 = new Rope() { Head = startingPosition, Tail = startingPosition, NextRope = rope8 };
var rope6 = new Rope() { Head = startingPosition, Tail = startingPosition, NextRope = rope7 };
var rope5 = new Rope() { Head = startingPosition, Tail = startingPosition, NextRope = rope6 };
var rope4 = new Rope() { Head = startingPosition, Tail = startingPosition, NextRope = rope5 };
var rope3 = new Rope() { Head = startingPosition, Tail = startingPosition, NextRope = rope4 };
var rope2 = new Rope() { Head = startingPosition, Tail = startingPosition, NextRope = rope3 };
var rope = new Rope() { Head = startingPosition, Tail = startingPosition, NextRope = rope2 };

foreach (ReadOnlySpan<char> line in input)
{
    if (line.Length < 3) continue;
    var movement = line[0];

    var steps = int.Parse(line[2..]);
    var distance = movement switch
    {
        'U' => new Vector2D { X = 0, Y = 1 },
        'D' => new Vector2D { X = 0, Y = -1 },
        'L' => new Vector2D { X = -1, Y = 0 },
        _ => new Vector2D { X = 1, Y = 0 },
    };
    for (var i = 0; i < steps; i++)
    {
        rope.PerformStep(distance, tailPart1Positions, tailPart2Positions);
    }
}

Console.WriteLine($"Solution for part 1: {tailPart1Positions.Count} tail movements");
Console.WriteLine($"Solution for part 2: {tailPart2Positions.Count} tail movements");

Shared.StopAndWriteExecutionTimer();

Console.ReadLine();
