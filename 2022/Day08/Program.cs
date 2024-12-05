using SharedLibs;

var input = Shared.LoadFromFileAsSpan("input.txt");

Shared.StartExecutionTimer();

var maxLength = input.Length;

var treeGrid = new int[maxLength, maxLength];

var currentRow = -1;
foreach (ReadOnlySpan<char> line in input)
{
    currentRow++;
    for (var i = 0; i < line.Length; i++)
    {
        treeGrid[currentRow,i] = line[i] - 48;
    }
}

var visibleTrees = (4 * maxLength) - 4;

var maximumScenicScore = 0;

for (var i = 1; i < maxLength - 1; i++)
{
    for (var j = 1; j < maxLength - 1; j++)
    {
        var visibleTop = true;
        var visibleBottom = true;
        var visibleLeft = true;
        var visibleRight = true;
        var scenicTop = 0;
        var scenicBottom = 0;
        var scenicLeft = 0;
        var scenicRight = 0;
        for (var k = i - 1; k >= 0; k--)
        {
            scenicTop++;
            if (treeGrid[k,j] >= treeGrid[i, j])
            {
                visibleTop = false;
                break;
            }
        }
        for (var k = i + 1; k < maxLength; k++)
        {
            scenicBottom++;
            if (treeGrid[k, j] >= treeGrid[i, j])
            {
                visibleBottom = false;
                break;
            }
        }
        for (var k = j - 1; k >= 0; k--)
        {
            scenicLeft++;
            if (treeGrid[i, k] >= treeGrid[i, j])
            {
                visibleLeft = false;
                break;
            }
        }
        for (var k = j + 1; k < maxLength; k++)
        {
            scenicRight++;
            if (treeGrid[i, k] >= treeGrid[i, j])
            {
                visibleRight = false;
                break;
            }
        }
        if (visibleTop || visibleBottom || visibleLeft || visibleRight)
        {
            visibleTrees++;
        }
        var scenicScore = scenicTop * scenicBottom * scenicLeft * scenicRight;
        if (maximumScenicScore < scenicScore)
        {
            maximumScenicScore = scenicScore;
        }
    }
}

Console.WriteLine($"Solution for part 1: {visibleTrees} visible trees");
Console.WriteLine($"Solution for part 2: {maximumScenicScore} scenic score");

Shared.StopAndWriteExecutionTimer();

Console.ReadLine();
