using System.Collections.Generic;

namespace Day3
{
    public class Slope
    {
        public List<List<SlopeType>> Columns { get; } = new List<List<SlopeType>>();

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public int LineLength { get; set; }

        public int LineCount { get; set; }

        public int MovementRight { get; set; }

        public int MovementBottom { get; set; }

        public long TreesEncountered { get; private set; }

        public Slope(List<string> inputLines)
        {
            LineLength = inputLines[0].Length;
            LineCount = inputLines.Count;
            PrepareColumns();
            for(int i = 0; i < LineLength; i++)
            {
                for(int j = 0; j < inputLines.Count; j++)
                {
                    Columns[i].Add(ParseType(inputLines[j][i]));
                }
            }
        }

        public void Start()
        {
            TreesEncountered = 0;
            while(PositionY < (LineCount-1))
            {
                PerformMovement();
                if (Columns[PositionX][PositionY] == SlopeType.Tree)
                {
                    TreesEncountered++;
                }
            }
        }

        private void PerformMovement()
        {
            PositionX = (PositionX + MovementRight) % LineLength;
            if ((PositionY + MovementBottom) < LineCount)
            {
                PositionY += MovementBottom;
            }
            else
            {
                PositionY = LineCount - 1;
            }
        }
        
        private void PrepareColumns()
        {
            for (var i = 0; i < LineLength; i++)
            {
                Columns.Add(new List<SlopeType>());
            }
        }

        private SlopeType ParseType(char type)
        {
            switch(type)
            {
                case '#':
                    return SlopeType.Tree;
                default:
                    return SlopeType.Slope;
            }
        }
    }
}
