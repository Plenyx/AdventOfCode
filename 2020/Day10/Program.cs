using AoCHelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    class Program
    {
        private static List<int> orderedAdapters;
        private static List<SortedSet<int>> allMustHops;

        static void Main(string[] args)
        {
            var input = InputLoader.GetInputAsList("input.txt");
            var adapters = input
                .Select(x => int.Parse(x))
                .ToList();
            adapters.Add(adapters.Max()+3);
            orderedAdapters = adapters.OrderBy(x => x).ToList();
            int jolt1 = 0, jolt2 = 0, jolt3 = 0, lastAdapter = 0;
            foreach(var adapter in orderedAdapters)
            {
                switch (adapter - lastAdapter)
                {
                    case 3:
                        jolt3++;
                        break;
                    case 2:
                        jolt2++;
                        break;
                    default:
                        jolt1++;
                        break;
                }
                lastAdapter = adapter;
            }
            Console.WriteLine($"Solution for task 1: {jolt1*jolt3}");
            // solution 2
            allMustHops = new List<SortedSet<int>>();
            lastAdapter = 0;
            foreach (var adapter in orderedAdapters)
            {
                if ((adapter - lastAdapter) == 3)
                {
                    allMustHops.Add(new SortedSet<int>() { lastAdapter, adapter });
                }
                lastAdapter = adapter;
            }

            allMustHops = allMustHops
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.First())
                .ToList();

            orderedAdapters = adapters.OrderBy(x => x).ToList();

            Console.WriteLine($"Solution for task 2: {CalculateHops(0)}");
            Console.ReadLine();
        }

        private static SortedSet<int> FindNearestMustHop(int position)
        {
            return allMustHops.Where(x => position <= x.First())
                .OrderBy(x => x.First())
                .FirstOrDefault();
        }

        private static List<int> possibleWays;

        private static void FindWays(int position)
        {
            var possibleWaysT = orderedAdapters
                .Where(x => (position + 3 >= x) && (position < x))
                .ToList();
            foreach(var way in possibleWaysT)
            {
                if (!allMustHops.Where(x => x.FirstOrDefault().Equals(way)).Any())
                {
                    FindWays(way);
                    possibleWays.AddUnique(way);
                }
            }
        }

        private static long CalculateHops(int position)
        {
            var nearestMustHop = FindNearestMustHop(position);
            while((nearestMustHop?.FirstOrDefault() ?? -1).Equals(position))
            {
                position = nearestMustHop.Last();
                nearestMustHop = FindNearestMustHop(position);
            }
            possibleWays = orderedAdapters
                .Where(x => (nearestMustHop?.FirstOrDefault() ?? -1) >= x && x > position)
                .ToList();

            if (orderedAdapters.Max() <= position)
            {
                return 1;
            }
            possibleWays.Add(position);
            foreach(var way in possibleWays.ToList())
            {
                if (!allMustHops.Where(x => x.FirstOrDefault().Equals(way)).Any())
                {
                    FindWays(way);
                }
            }
            return CalculateValidPaths(possibleWays, position, nearestMustHop.Last()) * ((nearestMustHop == null) ? 1L : CalculateHops(nearestMustHop.Last()));
        }

        private static long CalculateValidPaths(List<int> inputList, int beginning, int end)
        {
            var availablePath = new List<int>(inputList)
            {
                beginning,
                end
            }
                .OrderBy(x => x)
                .ToList();

            var validWays = new List<SortedSet<int>>
            {
                new SortedSet<int>() { beginning }
            };
            while (validWays.Where(x => !x.Last().Equals(end)).Any())
            {
                var lastNumbers = validWays
                    .Where(x => !x.Last().Equals(end))
                    .ToList();
                foreach(var set in lastNumbers)
                {
                    var plus1 = availablePath
                        .Where(x => set.Last() + 1 == x)
                        .Any();
                    var plus2 = availablePath
                        .Where(x => set.Last() + 2 == x)
                        .Any();
                    var plus3 = availablePath
                        .Where(x => set.Last() + 3 == x)
                        .Any();

                    if (plus1 && !plus2 && !plus3)
                    {
                        set.Add(set.Last() + 1);
                    }
                    else if (!plus1 && plus2 && !plus3)
                    {
                        set.Add(set.Last() + 2);
                    }
                    else if (!plus1 && !plus2 && plus3)
                    {
                        set.Add(set.Last() + 3);
                    }
                    else if(plus1 && plus2 && !plus3)
                    {
                        validWays.Add(new SortedSet<int>(set) { set.Last() + 2 });
                        set.Add(set.Last() + 1);
                    }
                    else if (plus1 && !plus2 && plus3)
                    {
                        validWays.Add(new SortedSet<int>(set) { set.Last() + 3 });
                        set.Add(set.Last() + 1);
                    }
                    else if (!plus1 && plus2 && plus3)
                    {
                        validWays.Add(new SortedSet<int>(set) { set.Last() + 3 });
                        set.Add(set.Last() + 2);
                    }
                    else //if (plus1 && plus2 && plus3)
                    {
                        validWays.Add(new SortedSet<int>(set) { set.Last() + 2 });
                        validWays.Add(new SortedSet<int>(set) { set.Last() + 3 });
                        set.Add(set.Last() + 1);
                    }
                }
            }
            return validWays.Count;
        }
    }
}
