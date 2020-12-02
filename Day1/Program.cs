using System;
using System.Linq;
using System.Collections.Generic;
using AoCInputLoader;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = (args.Count() > 0) ? InputLoader.GetInputAsNumberList(args[0]) : InputLoader.GetInputAsNumberList("input.txt");
            Console.WriteLine("*** Results for 2 numbers:");
            DoTwoNumbers(numberList);
            Console.WriteLine();
            Console.WriteLine("*** Results for 3 numbers:");
            DoThreeNumbers(numberList);
            Console.ReadLine();
        }

        public static void DoTwoNumbers(List<int> numberList)
        {
            for (var i = 0; i < numberList.Count; i++)
            {
                foreach (var number in numberList)
                {
                    if (numberList[i] + number == 2020)
                    {
                        Console.WriteLine($"Result found: {numberList[i]} + {number} = 2020 | Multiply: {numberList[i] * number}");
                    }
                }
            }
        }

        public static void DoThreeNumbers(List<int> numberList)
        {
            for(var i = 0; i < numberList.Count; i++)
            {
                for (var j = 0; j < numberList.Count; j++)
                {
                    foreach (var number in numberList)
                    {
                        if (numberList[i] + numberList[j] + number == 2020)
                        {
                            Console.WriteLine($"Result found: {numberList[i]} + {numberList[j]} + {number} = 2020 | Multiply: {numberList[i] * numberList[j] * number}");
                        }
                    }
                }
            }
        }
    }
}
