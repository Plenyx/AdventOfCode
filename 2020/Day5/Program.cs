using System;
using System.Linq;
using System.Collections.Generic;
using AoCHelperClasses;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputList = (args.Count() > 0) ? InputLoader.GetInputAsList(args[0]) : InputLoader.GetInputAsList("input.txt");
            var boardingPasses = inputList.Select(anon => BoardingPass.ParseInput(anon)).ToList();
            var highestID = boardingPasses.Max(anon => anon.SeatID);
            Console.WriteLine($"The highest seat ID (part 1): {highestID}");
            var emptySeats = new List<BoardingPass>();
            for(var i = 0; i < 128; i++)
            {
                for(var j = 0; j < 8; j++)
                {
                    var doesExistInPasses = boardingPasses
                        .Where(anon => anon.SeatID.Equals(i * 8 + j))
                        .Count();
                    if (doesExistInPasses == 0)
                    {
                        emptySeats.Add(new BoardingPass() { Row = i, Column = j });
                    }
                }
            }
            foreach(var mySeat in emptySeats)
            {
                var leftSeatExists = boardingPasses
                    .Where(anon => (mySeat.SeatID - 1).Equals(anon.SeatID))
                    .Count() != 0;
                var rightSeatExists = boardingPasses
                    .Where(anon => (mySeat.SeatID + 1).Equals(anon.SeatID))
                    .Count() != 0;
                if(leftSeatExists && rightSeatExists)
                {
                    Console.WriteLine($"My seat is ID: {mySeat.SeatID}");
                }
            }
            Console.ReadLine();
        }
    }
}
