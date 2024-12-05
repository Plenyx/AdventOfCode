using AoCHelperClasses;
using System;
using System.Linq;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = InputLoader.GetInputAsList("input.txt");
            var list = input
                .Select(x => new Instruction(x))
                .ToList();

            var simulation = new Simulation(list);
            simulation.Begin();

            Console.WriteLine($"Solution for task 1: {Math.Abs(simulation.ShipBasic.Location.X) + Math.Abs(simulation.ShipBasic.Location.Y)}");
            Console.WriteLine($"Solution for task 2: {Math.Abs(simulation.ShipWaypoint.Location.X) + Math.Abs(simulation.ShipWaypoint.Location.Y)}");

            Console.ReadLine();
        }
    }
}
