using SharedLibs;

var input = Shared.LoadFromFileAsSpan("input.txt");

Shared.StartExecutionTimer();

var cycle = 0;
var registerX = 1;

var signalStrength = 0;

var crt = new char[6, 40];

foreach (ReadOnlySpan<char> line in input)
{
    if (line.Length < 4) continue;
    if (line[0] == 'n') // noop
    {
        if (cycle <= 240)
        {
            crt[cycle / 40, cycle % 40] = (((cycle % 40) == (registerX % 40)) || ((cycle % 40) == ((registerX % 40) - 1)) || ((cycle % 40) == ((registerX % 40) + 1))) ? '#' : '.';
        }
        cycle++;
        if ((cycle == 20) || ((cycle - 20) % 40 == 0) && (cycle <= 220))
        {
            signalStrength += cycle * registerX;
        }
        continue;
    }
    // addx
    if (cycle <= 240)
    {
        crt[cycle / 40, cycle % 40] = (((cycle % 40) == (registerX % 40)) || ((cycle % 40) == ((registerX % 40) - 1)) || ((cycle % 40) == ((registerX % 40) + 1))) ? '#' : '.';
        crt[(cycle + 1) / 40, (cycle + 1) % 40] = ((((cycle % 40) + 1) == (registerX % 40)) || (((cycle % 40) + 1) == ((registerX % 40) - 1)) || (((cycle % 40) + 1) == ((registerX % 40) + 1))) ? '#' : '.';
    }
    cycle += 2;
    if (((cycle == 20) || ((cycle - 20) % 40 == 0)) && (cycle <= 220))
    {
        signalStrength += cycle * registerX;
    }
    if (((cycle == 21) || ((cycle - 21) % 40 == 0)) && (cycle <= 221))
    {
        signalStrength += (cycle - 1) * registerX;
    }
    registerX += int.Parse(line[5..]);
}

Console.WriteLine($"Solution for part 1: {signalStrength} signal strength");

Console.WriteLine("Solution for part 2:");

for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 40; j++)
    {
        Console.Write(crt[i,j]);
    }
    Console.WriteLine();
}

Shared.StopAndWriteExecutionTimer();

Console.ReadLine();
