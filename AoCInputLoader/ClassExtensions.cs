using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AoCHelperClasses
{
    public static class ClassExtensions
    {
        public static bool DoesMatchExactPattern(this String haystack, string pattern)
        {
            var regex = new Regex($"^({pattern})$", RegexOptions.Multiline);
            return regex.IsMatch(haystack);
        }

        public static void AddRangeUnique(this List<string> list, List<string> toAdd)
        {
            foreach(var add in toAdd)
            {
                if (!list.Contains(add))
                {
                    list.Add(add);
                }
            }
        }
    }
}
