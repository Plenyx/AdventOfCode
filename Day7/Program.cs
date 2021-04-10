using AoCHelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    class Program
    {
        public static Dictionary<string, Bag> BagDict { get; private set; }

        public static List<string> SearchedParents { get; private set; } = new List<string>();

        public static int RollingCount { get; set; } = 0;

        static void Main(string[] args)
        {
            var input = InputLoader.GetInputAsList("input.txt");
            BagDict = input
                .Select(x => new Bag(x))
                .ToDictionary(x => x.Name, x => x);
            var prepareParentsList = BagDict
                    .Where(x => x.Value.ContainsBags.ContainsKey("shiny gold bags"))
                    .Select(x => x.Key)
                    .ToList();
            SearchedParents.AddRangeUnique(prepareParentsList);
            RecursionParents(prepareParentsList);
            Console.WriteLine($"Solution for task 1: {SearchedParents.Count}");
            RecursionChildren("shiny gold bags", 1);
            Console.WriteLine($"Solution for task 2: {RollingCount-1}");
            Console.ReadLine();
        }

        static void RecursionParents(List<string> parents)
        {
            if (parents.Count == 0)
            {
                return;
            }
            foreach(var parent in parents)
            {
                var parentsOfParent = BagDict
                    .Where(x => x.Value.ContainsBags.ContainsKey(parent))
                    .Select(x => x.Key)
                    .ToList();
                SearchedParents.AddRangeUnique(parentsOfParent);
                RecursionParents(parentsOfParent);
            }
        }

        static void RecursionChildren(string child, int multiplication)
        {
            RollingCount += multiplication;
            var childBag = BagDict.Where(x => x.Key.Equals(child)).Select(x => x.Value).FirstOrDefault();
            foreach (var containedBag in childBag.ContainsBags.Keys)
            {
                RecursionChildren(containedBag, multiplication * childBag.ContainsBags[containedBag]);
            }
        }
    }
}
