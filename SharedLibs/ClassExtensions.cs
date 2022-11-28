using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace SharedLibs
{
    internal static class ClassExtensions
    {
        public static ReadOnlySpan<T> AsSpan<T>(this List<T> list)
        {
            return CollectionsMarshal.AsSpan(list);
        }

        public static bool DoesMatchExactPattern(this string haystack, string pattern)
        {
            var regex = new Regex($"^({pattern})$", RegexOptions.Multiline);
            return regex.IsMatch(haystack);
        }

        public static int ToInt(this bool booleanValue) => booleanValue ? 1 : 0;

        public static void AddUnique<T>(this ICollection<T> list, T toAdd)
        {
            if (!list.Contains(toAdd))
            {
                list.Add(toAdd);
            }
        }

        public static void AddRangeUnique<T>(this ICollection<T> list, List<T> toAdd)
        {
            foreach (var add in toAdd.AsSpan())
            {
                if (!list.Contains(add))
                {
                    list.Add(add);
                }
            }
        }
    }
}
