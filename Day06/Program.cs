using SharedLibs;

var input = Shared.LoadFromFileAsSpan("input.txt");

Shared.StartExecutionTimer();

ReadOnlySpan<char> line = input[0];

var helperStarterList = new List<char>() { 't', line[0], line[1], line[2] };

var processedCharactersStarter = 3;

for (int i = 3; i < line.Length; i++)
{
    processedCharactersStarter++;
    helperStarterList.RemoveAt(0);
    helperStarterList.Add(line[i]);
    if (helperStarterList.GroupBy(x => x).Count() == 4)
    {
        break;
    }
}

var helperMessageList = new List<char>() { 't' };

for (var i = 0; i < 13; i++)
{
    helperMessageList.Add(line[i]);
}

var processedCharactersMessage = 13;

for (int i = 13; i < line.Length; i++)
{
    processedCharactersMessage++;
    helperMessageList.RemoveAt(0);
    helperMessageList.Add(line[i]);
    if (helperMessageList.GroupBy(x => x).Count() == 14)
    {
        break;
    }
}

Console.WriteLine($"The solution for part 1: {processedCharactersStarter} letters");
Console.WriteLine($"The solution for part 2: {processedCharactersMessage} letters");

Shared.StopAndWriteExecutionTimer();

Console.ReadLine();
