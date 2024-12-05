using AoCHelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day9
{
    class Program
    {
        private static long NumberState { get; set; }

        static void Main(string[] args)
        {
            var input = InputLoader.GetInputAsList("input.txt")
                .Select(x => long.Parse(x))
                .ToList();
            var inputDict = new Dictionary<int, long>();
            for(int i = 0; i < input.Count; i++)
            {
                inputDict.Add(i, input[i]);
            }

            for(int i = 25; i < inputDict.Keys.Count; i++)
            {
                var preambule = inputDict
                    .Where(x => x.Key < i && x.Key >= i - 25)
                    .Select(x => x.Value)
                    .ToList();
                if (!IsSumOfPreambule(inputDict[i], preambule))
                {
                    break;
                }
            }
            Console.WriteLine($"Solution for task 1: {NumberState}");

            var numbersSum = new List<long>();
            for (int i = 0; i < inputDict.Keys.Count; i++)
            {
                var testSum = inputDict[i];
                var endingBool = false;
                numbersSum.Add(inputDict[i]);
                foreach (var subNumber in inputDict.Values.Skip(i+1))
                {
                    testSum += subNumber;
                    numbersSum.Add(subNumber);
                    if (testSum.Equals(NumberState))
                    {
                        endingBool = true;
                        break;
                    }
                }
                if (endingBool)
                {
                    break;
                }
                else
                {
                    numbersSum.Clear();
                }
            }
            Console.WriteLine($"Solution for task 2: {numbersSum.OrderBy(x => x).First()+numbersSum.OrderByDescending(x => x).First()}");
            Console.ReadLine();
        }

        private static bool IsSumOfPreambule(long presumedSum, List<long> preambule)
        {
            NumberState = presumedSum;
            foreach(var number in preambule)
            {
                var modifiedPreambule = preambule
                    .Where(x => !x.Equals(number))
                    .ToList();

                foreach(var secondNumber in modifiedPreambule)
                {
                    if ((number + secondNumber) == presumedSum)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
