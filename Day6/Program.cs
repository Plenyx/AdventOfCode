using System;
using System.Linq;
using System.Collections.Generic;
using AoCHelperClasses;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputList = (args.Count() > 0) ? InputLoader.GetInputAsList(args[0]) : InputLoader.GetInputAsList("input.txt");
            var customsInput = new List<List<string>>();
            var i = 0;
            customsInput.Add(new List<string>());
            foreach (var input in inputList)
            {
                if (!string.IsNullOrWhiteSpace(input))
                {
                    customsInput[i].Add(input);
                }
                else
                {
                    i++;
                    customsInput.Add(new List<string>());
                }
            }
            var customsText = new List<string>();
            foreach (var list in customsInput)
            {
                var passportText = "";
                list.ForEach(delegate (string e) { passportText += e; });
                customsText.Add(passportText);
            }
            // part 1
            var numberOfTotalAnswers = customsText
                .Select(anon => anon.Distinct())
                .Sum(anon => anon.Count());
            Console.WriteLine($"Number for part 1: {numberOfTotalAnswers}");
            // part 2 - very dirty way of doing it
            var customsMemberText = new List<List<string>>();
            var customsResultIntersect = new List<int>();
            foreach (var list in customsInput)
            {
                var passportText = "";
                list.ForEach(delegate (string e) { passportText += " " + e; });
                customsMemberText.Add(passportText.Trim().Split(' ').ToList());
            }
            for(i = 0; i < customsMemberText.Count; i++)
            {
                var first = customsMemberText[i][0];
                for (int j = 1; j < customsMemberText[i].Count; j++)
                {
                    first = new string(first.Intersect(customsMemberText[i][j]).ToArray());
                }
                customsResultIntersect.Add(first.Length);
            }
            var part2Result = customsResultIntersect.Sum();
            Console.WriteLine($"Number for part 2: {part2Result}");
            Console.ReadLine();
        }
    }
}
