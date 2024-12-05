using AoCHelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = InputLoader.GetInputAsList("input.txt");
            var list = input
                .Select(x => new List<Place>(x.ToList().Select(y => new Place(y)).ToList()))
                .ToList();

            var simulation1 = new SeatingSimulation(list);
            simulation1.BeginTask1Simulation();

            var simulationSeats = simulation1.Places.Select(x => x.Where(y => y.Type.Equals(PlaceType.TakenSeat)).Count()).Sum();
            Console.WriteLine($"Solution for task 1: {simulationSeats}");

            var simulation2 = new SeatingSimulation(list);
            simulation2.BeginTask2Simulation();

            simulationSeats = simulation2.Places.Select(x => x.Where(y => y.Type.Equals(PlaceType.TakenSeat)).Count()).Sum();
            Console.WriteLine($"Solution for task 2: {simulationSeats}");

            Console.ReadLine();
        }
    }
}
