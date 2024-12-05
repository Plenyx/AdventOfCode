namespace Day09
{
    internal sealed class Rope
    {
        public Vector2D Head { get; internal set; }
        public Vector2D Tail { get; internal set; }

        public Rope NextRope { get; internal set; }

        public bool IsHeadTouchningTail => Head.DistanceFrom(Tail) <= 1;

        public void PerformStep(Vector2D direction, HashSet<Vector2D> tailPart1Positions, HashSet<Vector2D> tailPart2Positions)
        {
            var previousHead = Head;
            Head = Head.Add(direction);
            if (!IsHeadTouchningTail)
            {
                if ((direction.X != 0) && (direction.Y != 0))
                {
                    if (Tail.Add(new Vector2D { X = direction.X, Y = 0 }).DistanceFromNonDiagonal(Head) == 1)
                    {
                        Tail = Tail.Add(new Vector2D { X = direction.X, Y = 0 });
                    }
                    else if (Tail.Add(new Vector2D { X = 0, Y = direction.Y }).DistanceFromNonDiagonal(Head) == 1)
                    {
                        Tail = Tail.Add(new Vector2D { X = 0, Y = direction.Y });
                    }
                    else
                    {
                        Tail = Tail.Add(direction);
                    }
                }
                else
                {
                    Tail = previousHead;
                }
                tailPart1Positions?.Add(Tail);
                if (NextRope is null)
                {
                    tailPart2Positions.Add(Tail);
                }
                if ((NextRope is not null) && (Tail.DistanceFrom(NextRope.Head) == 1))
                {
                    NextRope.PerformStep(Tail.DifferenceFrom(NextRope.Head), null, tailPart2Positions);
                }
            }
        }
    }
}
