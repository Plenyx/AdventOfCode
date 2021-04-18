namespace Day11
{
    public class Place
    {
        public PlaceType Type { get; set; }

        public Place(char input)
        {
            Type = input switch
            {
                'L' => PlaceType.EmptySeat,
                '#' => PlaceType.TakenSeat,
                _ => PlaceType.Floor
            };
        }

        private Place() { }

        public override string ToString() => Type switch { PlaceType.EmptySeat => "L", PlaceType.TakenSeat => "#", _ => "." };

        public Place ExactCopy() => new() { Type = Type };
    }
}
