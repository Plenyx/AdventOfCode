using System.Collections.Generic;

namespace Day12
{
    public class Simulation
    {
        public Element ShipBasic { get; } = new Element();
        public Element ShipWaypoint { get; } = new Element();

        public Coordinates Waypoint { get; } = new Coordinates();

        private List<Instruction> instructions;

        public Simulation(List<Instruction> instructions)
        {
            this.instructions = instructions;
            Waypoint.X = 10;
            Waypoint.Y = 1;
        }

        public void Begin()
        {
            foreach(var instruction in instructions)
            {
                ShipBasic.ProcessInstruction(instruction);
                ShipWaypoint.ProcessInstructionWithWaypoint(instruction, Waypoint);
            }
        }
    }
}
