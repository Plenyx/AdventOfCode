using System.Linq;

namespace Day2
{
    public class PasswordPositions : Password
    {
        /// <summary>
        /// Represents the minimal amount of how many times the character has to be present int the password.
        /// </summary>
        public int Position1Index { get; set; } = 0;

        /// <summary>
        /// Represents the maximal amount of how many times the character has to be present int the password.
        /// </summary>
        public int Position2Index { get; set; } = 0;

        override public bool IsValid
        {
            get => PasswordText[Position1Index].Equals(Character) ^ PasswordText[Position2Index].Equals(Character);
        }

        public static PasswordPositions ParseInput(string inputLine)
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
            if (int.TryParse(splitMinMax[0], out int position1))
            {
                if (int.TryParse(splitMinMax[1], out int position2))
                {
                    var character = splitSpaces[1][0];
                    var password = splitSpaces[2];
                    return new PasswordPositions() { Character = character, PasswordText = password, Position1Index = position1 - 1, Position2Index = position2 - 1 };
                }
            }
            return null;
        }
    }
}
