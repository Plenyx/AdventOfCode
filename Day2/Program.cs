using System;
using System.Linq;
using System.Collections.Generic;
using AoCInputLoader;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = (args.Count() > 0) ? InputLoader.GetInputAsList(args[0]) : InputLoader.GetInputAsList("input.txt");
            var passwordPart1ValidCount = inputList
                .Select(inputLine => PasswordMinMax.ParseInput(inputLine))
                .Where(password => password?.IsValid ?? false)
                .Count();
            Console.WriteLine($"Number of valid passwords for part 1: {passwordPart1ValidCount}");
            var passwordPart2ValidCount = inputList
                .Select(inputLine => PasswordPositions.ParseInput(inputLine))
                .Where(password => password?.IsValid ?? false)
                .Count();
            Console.WriteLine($"Number of valid passwords for part 2: {passwordPart2ValidCount}");
            Console.ReadLine();
        }
    }
}
