using System;
using System.Linq;
using System.Collections.Generic;
using AoCHelperClasses;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputList = (args.Count() > 0) ? InputLoader.GetInputAsList(args[0]) : InputLoader.GetInputAsList("input.txt");
            var passportsInput = new List<List<string>>();
            var i = 0;
            passportsInput.Add(new List<string>());
            foreach(var input in inputList)
            {
                if (!string.IsNullOrWhiteSpace(input))
                {
                    passportsInput[i].Add(input);
                }
                else
                {
                    i++;
                    passportsInput.Add(new List<string>());
                }
            }
            var passportsText = new List<string>();
            foreach(var list in passportsInput)
            {
                var passportText = "";
                list.ForEach(delegate (string e) { passportText += " " + e; });
                passportsText.Add(passportText.Trim());
            }
            var passports = passportsText.Select(anon => Passport.ParseString(anon)).ToList();
            Console.WriteLine($"Number of passports with all required fields (part 1): {passports.Where(anon => anon.HasRequiredFields).Count()}");
            Console.WriteLine($"Number of passports with correct fields (part 2): {passports.Where(anon => anon.HasRequiredFields && anon.AreFieldsValid).Count()}");
            Console.ReadLine();
        }
    }
}
