using AoCHelperClasses;
using System;
using System.Collections.Generic;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = InputLoader.GetInputAsList("input.txt");
            var dict = new Dictionary<int, Instruction>();
            for(int i = 0; i < input.Count; i++)
            {
                dict.Add(i, Instruction.FromInput(input[i]));
            }
            var simulator1 = new BootSimulator(dict);
            simulator1.BeginBoot();
            Console.WriteLine($"Solution for task 1: {simulator1.AccumulatorState}");
            var accResult = 0;
            foreach(var instructionId in dict.Keys)
            {
                var dictCopy = CopyDictionary(dict);
                if (dictCopy[instructionId].Type.Equals(InstructionType.DoNothing))
                {
                    dictCopy[instructionId].Type = InstructionType.Jump;
                    var simulator = new BootSimulator(dictCopy);
                    simulator.BeginBoot();
                    if (simulator.BootSimulatorState.Equals(BootSimulatorState.FinishedSuccess))
                    {
                        accResult = simulator.AccumulatorState;
                        break;
                    }
                }
                else if (dictCopy[instructionId].Type.Equals(InstructionType.Jump))
                {
                    dictCopy[instructionId].Type = InstructionType.DoNothing;
                    var simulator = new BootSimulator(dictCopy);
                    simulator.BeginBoot();
                    if (simulator.BootSimulatorState.Equals(BootSimulatorState.FinishedSuccess))
                    {
                        accResult = simulator.AccumulatorState;
                        break;
                    }
                }
            }
            Console.WriteLine($"Solution for task 2: {accResult}");
            Console.ReadLine();
        }

        private static Dictionary<int, Instruction> CopyDictionary(Dictionary<int, Instruction> original)
        {
            var copy = new Dictionary<int, Instruction>();
            foreach (var key in original.Keys)
            {
                copy.Add(key, Instruction.Copy(original[key]));
            }
            return copy;
        }
    }
}
