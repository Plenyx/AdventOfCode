using AoCHelperClasses;
using System.Collections.Generic;

namespace Day11
{
    public class SeatingSimulation
    {
        public List<List<Place>> Places { get; private set; }

        public int SeatsChanged { get; private set; }

        private List<List<Place>> oldStatePlaces;

        private readonly List<List<Place>> oldPlaces;

        public SeatingSimulation(List<List<Place>> places)
        {
            oldPlaces = places;
            ResetOldPlaces();
            ResetPlaces();
        }

        public void BeginTask1Simulation()
        {
            do
            {
                ApplyToOldPlaces();
                DoTask1Seating();
            }
            while (SeatsChanged != 0);
        }

        public void BeginTask2Simulation()
        {
            do
            {
                ApplyToOldPlaces();
                DoTask2Seating();
            }
            while (SeatsChanged != 0);
        }

        private void DoTask1Seating()
        {
            SeatsChanged = 0;
            for (int i = 0; i < oldStatePlaces.Count; i++)
            {
                for (int j = 0; j < oldStatePlaces[i].Count; j++)
                {
                    bool topLeft = IsSeatEmpty(i-1, j-1), top = IsSeatEmpty(i-1, j), topRight = IsSeatEmpty(i-1, j+1),
                        left = IsSeatEmpty(i, j-1), right = IsSeatEmpty(i, j+1),
                        bottomLeft = IsSeatEmpty(i+1, j-1), bottom = IsSeatEmpty(i+1, j), bottomRight = IsSeatEmpty(i+1, j+1);
                    var sumAll = topLeft.ToInt() + top.ToInt() + topRight.ToInt() + left.ToInt() + right.ToInt() + bottomLeft.ToInt() + bottom.ToInt() + bottomRight.ToInt();
                    if ((oldStatePlaces[i][j].Type == PlaceType.EmptySeat) && (sumAll == 8))
                    {
                        Places[i][j].Type = PlaceType.TakenSeat;
                        SeatsChanged++;
                    }
                    else if ((oldStatePlaces[i][j].Type == PlaceType.TakenSeat) && (sumAll <= 4))
                    {
                        Places[i][j].Type = PlaceType.EmptySeat;
                        SeatsChanged++;
                    }
                }
            }
        }

        private void DoTask2Seating()
        {
            SeatsChanged = 0;
            for (int i = 0; i < oldStatePlaces.Count; i++)
            {
                for (int j = 0; j < oldStatePlaces[i].Count; j++)
                {
                    bool topLeft = IsSeatEmptyTask2(i - 1, j - 1, -1, -1), top = IsSeatEmptyTask2(i - 1, j, -1, 0), topRight = IsSeatEmptyTask2(i - 1, j + 1, -1, 1),
                        left = IsSeatEmptyTask2(i, j - 1, 0, -1), right = IsSeatEmptyTask2(i, j + 1, 0, 1),
                        bottomLeft = IsSeatEmptyTask2(i + 1, j - 1, 1, -1), bottom = IsSeatEmptyTask2(i + 1, j, 1, 0), bottomRight = IsSeatEmptyTask2(i + 1, j + 1, 1, 1);
                    var sumAll = topLeft.ToInt() + top.ToInt() + topRight.ToInt() + left.ToInt() + right.ToInt() + bottomLeft.ToInt() + bottom.ToInt() + bottomRight.ToInt();
                    if ((oldStatePlaces[i][j].Type == PlaceType.EmptySeat) && (sumAll == 8))
                    {
                        Places[i][j].Type = PlaceType.TakenSeat;
                        SeatsChanged++;
                    }
                    else if ((oldStatePlaces[i][j].Type == PlaceType.TakenSeat) && (sumAll <= 3))
                    {
                        Places[i][j].Type = PlaceType.EmptySeat;
                        SeatsChanged++;
                    }
                }
            }
        }

        private bool IsSeatEmpty(int row, int column)
        {
            if ((row == oldStatePlaces.Count) || (row == -1) || (column == oldStatePlaces[0].Count) || (column == -1))
            {
                return true;
            }
            return oldStatePlaces[row][column].Type != PlaceType.TakenSeat;
        }

        private bool IsSeatEmptyTask2(int row, int column, int directionI, int directionJ)
        {
            if ((row == oldStatePlaces.Count) || (row == -1) || (column == oldStatePlaces[0].Count) || (column == -1))
            {
                return true;
            }
            if (oldStatePlaces[row][column].Type == PlaceType.Floor)
            {
                return IsSeatEmptyTask2(row + directionI, column + directionJ, directionI, directionJ);
            }
            return oldStatePlaces[row][column].Type != PlaceType.TakenSeat;
        }

        private void ResetPlaces()
        {
            Places = new List<List<Place>>();
            foreach(var row in oldPlaces)
            {
                var newRow = new List<Place>();
                foreach(var column in row)
                {
                    newRow.Add(column.ExactCopy());
                }
                Places.Add(newRow);
            }
        }

        private void ResetOldPlaces()
        {
            oldStatePlaces = new List<List<Place>>();
            foreach (var row in oldPlaces)
            {
                var newRow = new List<Place>();
                foreach (var column in row)
                {
                    newRow.Add(column.ExactCopy());
                }
                oldStatePlaces.Add(newRow);
            }
        }

        private void ApplyToOldPlaces()
        {
            oldStatePlaces = new List<List<Place>>();
            foreach (var row in Places)
            {
                var newRow = new List<Place>();
                foreach (var column in row)
                {
                    newRow.Add(column.ExactCopy());
                }
                oldStatePlaces.Add(newRow);
            }
        }
    }
}
