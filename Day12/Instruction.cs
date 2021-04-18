namespace Day12
{
    public class Instruction
    {
        public InstructionType Type { get; set; }

        public int By { get; set; }

        public Instruction(string input)
        {
            Type = (input[0]) switch
            {
                'N' => InstructionType.North,
                'S' => InstructionType.South,
                'E' => InstructionType.East,
                'W' => InstructionType.West,
                'L' => InstructionType.Left,
                'R' => InstructionType.Right,
                _ => InstructionType.Forward
            };
            By = int.Parse(input[1..]);
        }
    }
}
