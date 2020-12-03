using System;
using System.Linq;
using System.Collections.Generic;
using AoCInputLoader;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = (args.Count() > 0) ? InputLoader.GetInputAsList(args[0]) : InputLoader.GetInputAsList("input.txt");
            var slope = new Slope(inputList) { PositionX = 0, PositionY = 0, MovementRight = 3, MovementBottom = 1 };
            slope.Start();
            Console.WriteLine($"Trees encountered in part 1: {slope.TreesEncountered}");
            // right 3, below 1
            var slope31 = slope.TreesEncountered;
            // right 1, below 1
            slope.PositionX = slope.PositionY = 0;
            slope.MovementRight = slope.MovementBottom = 1;
            slope.Start();
            var slope11 = slope.TreesEncountered;
            // right 5, below 1
            slope.PositionX = slope.PositionY = 0;
            slope.MovementRight = 5;
            slope.MovementBottom = 1;
            slope.Start();
            var slope51 = slope.TreesEncountered;
            // right 7, below 1
            slope.PositionX = slope.PositionY = 0;
            slope.MovementRight = 7;
            slope.MovementBottom = 1;
            slope.Start();
            var slope71 = slope.TreesEncountered;
            // right 1, below 2
            slope.PositionX = slope.PositionY = 0;
            slope.MovementRight = 1;
            slope.MovementBottom = 2;
            slope.Start();
            var slope12 = slope.TreesEncountered;
            // part 2
            Console.WriteLine($"Number for part 2: {slope11*slope31*slope51*slope71*slope12}");
            Console.ReadLine();
        }
    }
}
