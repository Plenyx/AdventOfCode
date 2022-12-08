using Day07;
using SharedLibs;

var input = Shared.LoadFromFileAsSpan("input.txt");

Shared.StartExecutionTimer();

var root = new MyDirectory() { Name = "" };

var currentDirectory = root;

foreach (ReadOnlySpan<char> line in input)
{
    if (line[0] == '$')
    {
        if ((line[2] == 'c') && (line[3] == 'd'))
        {
            if (line[5] == '/')
            {
                currentDirectory = root;
                continue;
            }
            if ((line[5] == '.') && (line[6] == '.'))
            {
                currentDirectory = currentDirectory?.Parent;
                continue;
            }
            currentDirectory = currentDirectory?.GetOrCreateSubdirectory(line[5..]);
        }
        continue;
    }
    if (line[0] == 'd')
    {
        continue;
    }
    var nameSpace = line.IndexOf(' ');
    var fileName = line[(nameSpace + 1)..];
    var fileSize = line[0..nameSpace];
    currentDirectory.GetOrCreateFile(fileName, fileSize);
}

const int lowerThanSize = 100000;

Console.WriteLine($"The solution for part 1: {root.GetAllSubdirectoriesLowerThan(lowerThanSize).Sum(x => x.Size)}");

const int maxFileSystemSizeBeforeUpdate = 70000000 - 30000000;

Console.WriteLine($"The solution for part 2: {root.GetAllSubdirectoriesHigherThan(root.Size - maxFileSystemSizeBeforeUpdate).OrderBy(x => x.Size).FirstOrDefault()?.Size}");

Shared.StopAndWriteExecutionTimer();

Console.ReadLine();
