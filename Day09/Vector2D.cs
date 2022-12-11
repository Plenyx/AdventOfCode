namespace Day09
{
    internal readonly struct Vector2D
    {
        public int X { get; init; }
        public int Y { get; init; }

        public Vector2D Add(Vector2D v) => new() { X = X + v.X, Y = Y + v.Y };

        public int DistanceFrom(Vector2D other)
        {
            var xDifferrence = Math.Abs(X - other.X);
            var yDifferrence = Math.Abs(Y - other.Y);
            if ((xDifferrence == yDifferrence) || (xDifferrence > yDifferrence))
            {
                return xDifferrence;
            }
            return yDifferrence;
        }

        public int DistanceFromNonDiagonal(Vector2D other) => Math.Abs(X - other.X) + Math.Abs(Y - other.Y);

        public Vector2D DifferenceFrom(Vector2D other) => new() { X = X - other.X, Y = Y - other.Y };
    }
}
