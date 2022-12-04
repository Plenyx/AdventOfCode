using SharedLibs;

var input = Shared.LoadFromFileAsSpan("input.txt");

Shared.StartExecutionTimer();

var priorityNumber = 0;

foreach (ReadOnlySpan<char> line in input)
{
    var halfCount = line.Length / 2;
    ReadOnlySpan<char> rucksack1 = line[..halfCount];
    ReadOnlySpan<char> rucksack2 = line[halfCount..];
    foreach (var character in rucksack1)
    {
        if (rucksack2.LastIndexOf(character) != -1)
        {
            priorityNumber += (character < 97) ? character - 64 + 26 : character - 96;
            break;
        }
    }
}

Console.WriteLine($"The solution for part 1: {priorityNumber} priority points");

priorityNumber = 0;

for (int i = 0; i < input.Length; i += 3)
{
    ReadOnlySpan<char> elf1 = input[i];
    ReadOnlySpan<char> elf2 = input[i + 1];
    ReadOnlySpan<char> elf3 = input[i + 2];
    foreach (char character in elf1)
    {
        if (elf2.LastIndexOf(character) != -1 && elf3.LastIndexOf(character) != -1)
        {
            priorityNumber += (character < 97) ? character - 64 + 26 : character - 96;
            break;
        }
    }
}

Console.WriteLine($"The solution for part 2: {priorityNumber} priority points");

Shared.StopAndWriteExecutionTimer();

Console.ReadLine();
