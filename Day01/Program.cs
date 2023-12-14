using SharedLibs;

var input = Shared.LoadFromFileAsSpan("input.txt");

ReadOnlySpan<char> searchChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
var letteredWords = new Dictionary<char[], int>() {
    { new char[] { 'o', 'n', 'e' }, 1 },
    { new char[] { 't', 'w', 'o' }, 2 },
    { new char[] { 't', 'h', 'r', 'e', 'e' }, 3 },
    { new char[] { 'f', 'o', 'u', 'r' }, 4 },
    { new char[] { 'f', 'i', 'v', 'e' }, 5 },
    { new char[] { 's', 'i', 'x' }, 6 },
    { new char[] { 's', 'e', 'v', 'e', 'n' }, 7 },
    { new char[] { 'e', 'i', 'g', 'h', 't' }, 8 },
    { new char[] { 'n', 'i', 'n', 'e' }, 9 },
};

var part1Result = 0;
var part2Result = 0;

var firstNumber = 0;
var secondNumber = 0;

Shared.StartExecutionTimer();

foreach (ReadOnlySpan<char> line in input)
{
    var firstNumberIndex = line.IndexOfAny(searchChars);
    if (firstNumberIndex < 0)
    {
        continue;
    }
    firstNumber = line[firstNumberIndex] - 48;
    var secondNumberIndex = line.LastIndexOfAny(searchChars);
    secondNumber = line[secondNumberIndex] - 48;
    part1Result += firstNumber * 10 + secondNumber;
}

Console.WriteLine($"Solution to part 1: {part1Result}");

foreach (ReadOnlySpan<char> line in input)
{
    firstNumber = 0;
    secondNumber = 0;
    var firstNumberIndex = line.IndexOfAny(searchChars);
    var firstWordIndex = int.MaxValue;
    var lastWordIndex = -1;
    foreach (var word in letteredWords.Keys)
    {
        ReadOnlySpan<char> spannedWord = word;
        var localFirstWordIndex = line.IndexOf(spannedWord);
        if (localFirstWordIndex < firstWordIndex && localFirstWordIndex > -1)
        {
            firstWordIndex = localFirstWordIndex;
            firstNumber = letteredWords[word];
        }
        var localLastWordIndex = line.LastIndexOf(spannedWord);
        if (localLastWordIndex > lastWordIndex)
        {
            lastWordIndex = localLastWordIndex;
            secondNumber = letteredWords[word];
        }
    }
    if (firstNumberIndex < 0 && firstWordIndex < 0)
    {
        continue;
    }
    if (firstNumberIndex > -1 && (firstNumberIndex < firstWordIndex) || (firstWordIndex == -1))
    {
        firstNumber = line[firstNumberIndex] - 48;
    }
    var secondNumberIndex = line.LastIndexOfAny(searchChars);
    if (secondNumberIndex > lastWordIndex)
    {
        secondNumber = line[secondNumberIndex] - 48;
    }
    part2Result += firstNumber * 10 + secondNumber;
}

Console.WriteLine($"Solution to part 2: {part2Result}");

Shared.StopAndWriteExecutionTimer();

Console.ReadLine();
