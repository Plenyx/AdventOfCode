namespace Day8
{
    public class Instruction
    {
        public InstructionType Type { get; set; }

        public int By { get; private set; }

        private Instruction() { }

        private Instruction(string type, string argument)
        {
            Type = (type) switch
            {
                "acc" => InstructionType.Accumulate,
                "jmp" => InstructionType.Jump,
                _ => InstructionType.DoNothing
            };
            By = (argument[0]) switch
            {
                '+' => int.Parse(argument[1..]),
                _ => -int.Parse(argument[1..])
            };
        }

        public static Instruction FromInput(string input)
        {
            var split = input.Split(' ');
            return new Instruction(split[0], split[1]);
        }

        public static Instruction Copy(Instruction original)
        {
            return new Instruction() { Type = original.Type, By = original.By };
        }
    }
}
