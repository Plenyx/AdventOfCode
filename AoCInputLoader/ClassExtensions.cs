﻿using System;
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
    }
}
