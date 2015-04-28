using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacetrackMetricAnalysis.Classes;

namespace RacetrackMetricAnalysis
{
    class Program_Full : IProgram
    {
        public void Execute(string[] args)
        {
            RacetrackAnalyzer analyzer = new RacetrackAnalyzer();

            for (int i = 2; i < 7; i++)
            {
                int endJValue = (i == 6) ? 6 : 7;
                for (int j = i; j <= endJValue; j++)
                {
                    Console.WriteLine("Starting " + i + "x" + j + "...");

                    string[] loops = System.IO.File.ReadAllLines(RacetrackMetricAnalysis.Properties.Settings.Default.FilePath + @"\PCG-Racing\RacetrackMetricAnalysis\RacetrackMetricAnalysis\racetrackmetricanalysis\Loops\Loops_" + i + "x" + j + ".txt");

                    ProgramHelper.ProcessMetrics(loops, analyzer, OutputMode.Grade);

                    System.IO.File.WriteAllLines(RacetrackMetricAnalysis.Properties.Settings.Default.FilePath + @"\PCG-Racing\RacetrackMetricAnalysis\RacetrackMetricAnalysis\racetrackmetricanalysis\LoopsWithMetrics\Loops_" + i + "x" + j + ".txt", loops);

                    Console.WriteLine("Finished " + i + "x" + j + "!");
                }
            }
        }
    }
}
