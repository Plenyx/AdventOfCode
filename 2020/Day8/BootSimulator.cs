using System.Collections.Generic;

namespace Day8
{
    public class BootSimulator
    {
        public Dictionary<int, Instruction> Sequence { get; }

        public List<int> FinishedCommands { get; } = new List<int>();

        public int AccumulatorState { get; private set; } = 0;

        public BootSimulatorState BootSimulatorState { get; private set; } = BootSimulatorState.NotRan;

        public BootSimulator(Dictionary<int, Instruction> sequence)
        {
            Sequence = sequence;
        }

        public void BeginBoot()
        {
            FinishedCommands.Clear();
            AccumulatorState = 0;

            for(int instructionId = 0; instructionId < Sequence.Keys.Count;)
            {
                var instruction = Sequence[instructionId];
                if (FinishedCommands.Contains(instructionId))
                {
                    BootSimulatorState = BootSimulatorState.FinishedFail;
                    return;
                }
                FinishedCommands.Add(instructionId);
                if (instruction.Type.Equals(InstructionType.Accumulate))
                {
                    AccumulatorState += instruction.By;
                    instructionId++;
                }
                else if (instruction.Type.Equals(InstructionType.Jump))
                {
                    instructionId += instruction.By;
                }
                else
                {
                    instructionId++;
                }
            }
            BootSimulatorState = BootSimulatorState.FinishedSuccess;
        }
    }
}
