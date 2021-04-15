using System;
using System.Linq;
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

        public static void AddUnique<T>(this ICollection<T> list, T toAdd)
        {
            if (!list.Contains(toAdd))
            {
                list.Add(toAdd);
            }
        }

        public static void AddUnique(this List<SortedSet<int>> list, SortedSet<int> toAdd)
        {
            if (!list.Where(x => x.SetEquals(toAdd)).Any())
            {
                list.Add(toAdd);
            }
        }

        public static void AddRangeUnique<T>(this ICollection<T> list, ICollection<T> toAdd)
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
