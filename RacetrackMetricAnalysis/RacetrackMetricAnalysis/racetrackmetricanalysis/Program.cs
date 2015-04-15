using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacetrackMetricAnalysis
{
    class Program
    {
        private const ProgramType type = ProgramType.Hierarchical;

        public static void Main(string[] args)
        {
            IProgram program;

            if (type == ProgramType.Hierarchical)
                program = new ProgramHierarchical();
            else
                program = new Program_Full();

            program.Execute(args);
        }

        public enum ProgramType
        {
            Full,
            Hierarchical
        }
    }
}
