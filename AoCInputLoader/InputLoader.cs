using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AoCHelperClasses
{
    public static class InputLoader
    {
        public static List<string> GetInputAsList(string filename)
        {
            var generatedList = new List<string>();
            if (File.Exists(filename))
            {
                try
                {
                    using var reader = new StreamReader(filename);
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        generatedList.Add(line);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error encountered: {e.Message}");
                }
            }
            else
            {
                Console.WriteLine($"File '{filename}' does not exist");
            }
            return generatedList;
        }

        public static List<int> GetInputAsNumberList(string filename) => GetInputAsList(filename).Cast<int>().ToList();
    }
}
