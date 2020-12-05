using System;

namespace Day5
{
    public class BoardingPass
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public int SeatID
        {
            get
            {
                return Row * 8 + Column;
            }
        }

        public static BoardingPass ParseInput(string input)
        {
            // row
            int rowBelow = 0;
            int rowUpper = 127;
            foreach (var character in input[0..^3])
            {
                switch(character)
                {
                    case 'F':
                        rowUpper -= (rowUpper - rowBelow + 1) / 2;
                        break;
                    case 'B':
                        rowBelow += (rowUpper - rowBelow + 1) / 2;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            int columnBelow = 0;
            int columnUpper = 7;
            foreach (var character in input[7..])
            {
                switch (character)
                {
                    case 'L':
                        columnUpper -= (columnUpper - columnBelow + 1) / 2;
                        break;
                    case 'R':
                        columnBelow += (columnUpper - columnBelow + 1) / 2;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            return new BoardingPass() { Row = rowBelow, Column = columnBelow };
        }
    }
}
