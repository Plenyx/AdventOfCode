using System.Linq;
using System.Text.RegularExpressions;

namespace Day2
{
    public class PasswordMinMax : Password
    {
        /// <summary>
        /// Represents the minimal amount of how many times the character has to be present int the password.
        /// </summary>
        public int MinAmount { get; set; } = 0;

        /// <summary>
        /// Represents the maximal amount of how many times the character has to be present int the password.
        /// </summary>
        public int MaxAmount { get; set; } = int.MaxValue;

        override public bool IsValid
        {
            get
            {
                var regex = new Regex($"{Character}", RegexOptions.None);
                var matches = regex.Matches(PasswordText);
                return matches.Count >= MinAmount && matches.Count <= MaxAmount;
            }
        }

        public static PasswordMinMax ParseInput(string inputLine)
        {
            var splitSpaces = inputLine.Split(' ');
            if (splitSpaces.Count() != 3)
            {
                return null;
            }
            var splitMinMax = splitSpaces[0].Split('-');
            if (splitMinMax.Count() != 2)
            {
                return null;
            }
            if (int.TryParse(splitMinMax[0], out int minValue))
            {
                if (int.TryParse(splitMinMax[1], out int maxValue))
                {
                    var character = splitSpaces[1][0];
                    var password = splitSpaces[2];
                    return new PasswordMinMax() { Character = character, PasswordText = password, MinAmount = minValue, MaxAmount = maxValue };
                }
            }
            return null;
        }
    }
}
