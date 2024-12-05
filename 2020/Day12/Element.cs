namespace Day12
{
    public class Element
    {
        private int _heading = 90;
        public int Heading
        {
            get
            {
                return _heading;
            }
            private set
            {
                _heading = value % 360;
            }
        }

        public Coordinates Location { get; private set; } = new Coordinates();

        public void ProcessInstruction(Instruction instruction)
        {
            switch (instruction.Type)
            {
                case InstructionType.North:
                    MoveXY(0, instruction.By);
                    break;
                case InstructionType.South:
                    MoveXY(0, -instruction.By);
                    break;
                case InstructionType.West:
                    MoveXY(-instruction.By, 0);
                    break;
                case InstructionType.East:
                    MoveXY(instruction.By, 0);
                    break;
                case InstructionType.Left:
                    Rotate(-instruction.By);
                    break;
                case InstructionType.Right:
                    Rotate(instruction.By);
                    break;
                default: // forward
                    if (Heading == 0) // north
                    {
                        MoveXY(0, instruction.By);
                    }
                    else if ((Heading == -90) || (Heading == 270)) // west
                    {
                        MoveXY(-instruction.By, 0);
                    }
                    else if ((Heading == -180) || (Heading == 180)) // south
                    {
                        MoveXY(0, -instruction.By);
                    }
                    else // east
                    {
                        MoveXY(instruction.By, 0);
                    }
                    break;
            }
        }

        public void ProcessInstructionWithWaypoint(Instruction instruction, Coordinates waypoint)
        {
            switch (instruction.Type)
            {
                case InstructionType.North:
                    MoveWaypointXY(waypoint, 0, instruction.By);
                    break;
                case InstructionType.South:
                    MoveWaypointXY(waypoint, 0, -instruction.By);
                    break;
                case InstructionType.West:
                    MoveWaypointXY(waypoint, -instruction.By, 0);
                    break;
                case InstructionType.East:
                    MoveWaypointXY(waypoint, instruction.By, 0);
                    break;
                case InstructionType.Left:
                    RotateWaypoint(waypoint, -instruction.By);
                    break;
                case InstructionType.Right:
                    RotateWaypoint(waypoint, instruction.By);
                    break;
                default:
                    MoveXY(instruction.By * waypoint.X, instruction.By * waypoint.Y);
                    break;
            }
        }

        private void Rotate(int degrees)
        {
            Heading += degrees;
        }

        private void MoveXY(int x, int y)
        {
            Location.X += x;
            Location.Y += y;
        }

        private void RotateWaypoint(Coordinates waypoint, int degrees)
        {
            Heading = degrees;
            if ((Heading == -90) || (Heading == 270)) // west
            {
                var temp = waypoint.X;
                waypoint.X = -waypoint.Y;
                waypoint.Y = temp;
            }
            else if ((Heading == -180) || (Heading == 180)) // south
            {
                waypoint.X = -waypoint.X;
                waypoint.Y = -waypoint.Y;
            }
            else // 90 OR -270
            {
                var temp = waypoint.X;
                waypoint.X = waypoint.Y;
                waypoint.Y = -temp;
            }
        }

        private void MoveWaypointXY(Coordinates waypoint, int x, int y)
        {
            waypoint.X += x;
            waypoint.Y += y;
        }
    }
}
