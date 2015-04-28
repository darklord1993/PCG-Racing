using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacetrackMetricAnalysis.Classes;

namespace RacetrackMetricAnalysis
{
    public class ProgramHierarchical : IProgram
    {
        private static List<string> hierarchicalTypes = new List<string>() 
        {
            "BottomLeft",
            "BottomRight",
            "TopLeft",
            "TopRight",
            "LeftRight",
            "UpDown",
            "NoRoad"
        };

        public void Execute(string[] args)
        {

            RacetrackAnalyzer analyzer = new RacetrackAnalyzer();

            for (int i = 0; i < hierarchicalTypes.Count; i++)
            {
                Console.WriteLine("Starting " + hierarchicalTypes[i] + "...");

                string[] loops = System.IO.File.ReadAllLines(RacetrackMetricAnalysis.Properties.Settings.Default.FilePath + @"\PCG-Racing\HierarchicalTileWalkthroughs\" + hierarchicalTypes[i] + "_5x5.txt");

                ProgramHelper.ProcessMetrics(loops, analyzer, OutputMode.Grade);

                System.IO.File.WriteAllLines(RacetrackMetricAnalysis.Properties.Settings.Default.FilePath + @"\PCG-Racing\HierarchicalTileWalkthroughs\Metrics\" + hierarchicalTypes[i] + "_5x5.txt", loops);

                Console.WriteLine("Finished " + hierarchicalTypes[i] + "!");
            }
        }
    }
}
