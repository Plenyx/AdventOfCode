using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    public class Bag
    {
        public string Name { get; set; }

        public Dictionary<string, int> ContainsBags { get; private set; }

        public Bag(string inputText)
        {
            var split = inputText.Split(new string[] { "contain" }, StringSplitOptions.None);
            Name = split[0].Trim();
            var bagsSplitHack = split[1].Split('.')[0].Trim();
            ContainsBags = bagsSplitHack
                .Split(',')
                .Select(x => x.Trim())
                .Where(x => x != "no other bags")
                .Select(x => new { Name = x.Split(' ', 2)[1], Value = int.Parse(x.Split(' ', 2)[0]) })
                .ToDictionary(x => (x.Name.Contains("bags") ? x.Name : $"{x.Name}s"), x => x.Value);
        }
    }
}
