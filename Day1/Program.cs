using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = (args.Count() > 0) ? GetNumberList(args[0]) : GetNumberList("input.txt");
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

        public static List<int> GetNumberList(string filename)
        {
            var numberList = new List<int>();
            if (File.Exists(filename))
            {
                try
                {
                    using var reader = new StreamReader(filename);
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out int number))
                        {
                            numberList.Add(number);
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Error encountered: {e.Message}");
                }
            }
            else
            {
                Console.WriteLine($"File '{filename}' does not exist");
            }
            return numberList.OrderBy(a => a).ToList();
        }
    }
}
