using AoCHelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day13
{
    class Program
    {
        static void Main()
        {
            var input = InputLoader.GetInputAsList("input.txt");
            var timestamp = int.Parse(input[0]);
            var earliestBus = input[1]
                .Split(',')
                .Where(x => x != "x")
                .Select(x => long.Parse(x))
                .Select(x => new { BusID = x, TimestampRemaining = x - timestamp % x })
                .OrderBy(x => x.TimestampRemaining)
                .First();

            Console.WriteLine($"Solution for task 1: {earliestBus.BusID * earliestBus.TimestampRemaining}");

            var inputBusses = input[1]
                .Split(',')
                .Select(x => x == "x" ? 0 : long.Parse(x))
                .ToList();

            var busses = new List<BusHelp>();
            var offset = 0L;
            foreach (var bus in inputBusses)
            {
                if (!bus.Equals(0))
                {
                    busses.Add(new BusHelp() { BusID = bus, OffsetReq = offset });
                }
                offset++;
            }

            var solution2 = 0L;
            var range = busses.Select(x => x.BusID).Aggregate((x, y) => x*y);

            foreach (var bus in busses)
            {
                var modulo = (((bus.BusID - bus.OffsetReq) % bus.BusID) + bus.BusID) % bus.BusID;
                var sub = range / bus.BusID;
                var inverse = GetInverseNumber(sub, bus.BusID);

                solution2 += modulo * sub * inverse;
            }
            solution2 %= range;

            Console.WriteLine($"Solution for task 2: {solution2}");
            Console.ReadLine();
        }

        private static long GetInverseNumber(long sub, long busId)
        {
            var remainder = sub % busId;
            for (long inverse = 0; inverse < busId - 1; inverse++)
            {
                if ((remainder * (inverse + 1)) % busId == 1)
                {
                    return inverse + 1;
                }
            }
            return 1;
        }
    }
}
