using RacetrackMetricAnalysis.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacetrackMetricAnalysis
{
    public static class ProgramHelper
    {
        public static void ProcessMetrics(string[] loops, RacetrackAnalyzer analyzer)
        {
            RacetrackMetrics metrics;
            int endStraights = 0, endSuperStraights = 0, endTurns = 0, endConsecutiveTurns = 0, longestSuperStraight = 0, longestConsecutiveTurns = 0;

            for (int i = 0; i < loops.Length; i++)
            {
                metrics = analyzer.GetMetrics(loops[i]);
                endStraights += metrics.NumberOfStraights;
                endSuperStraights += metrics.NumberOfSuperStraights;
                endTurns += metrics.NumberOfTurns;
                endConsecutiveTurns += metrics.NumberOfConsecutiveTurns;
                if (metrics.NumberOfSuperStraights > longestSuperStraight)
                {
                    longestSuperStraight = metrics.NumberOfSuperStraights;
                }
                if (metrics.NumberOfConsecutiveTurns > longestConsecutiveTurns)
                {
                    longestConsecutiveTurns = metrics.NumberOfConsecutiveTurns;
                }

                loops[i] = CreateCommaSeparatedLoopWithMetricValues(loops[i], metrics);
            }
            string result = "Straight Aways: " + endStraights + "\n" + "Super Straight Aways: " + endSuperStraights + "\n" + "Turns: " + endTurns + "\n"
                + "Consecutive Turns: " + endConsecutiveTurns + "\n" + "Longest Super Straight: " + longestSuperStraight + "\n" + "Longest Consecutive Turn: " + longestConsecutiveTurns;
            System.IO.File.WriteAllText(@"C:\Users\Chase Plante\Documents\GitHub\PCG-Racing\RacetrackMetricAnalysis\RacetrackMetricAnalysis\racetrackmetricanalysis\OutputMetrics\Results.txt", result);
        }

        public static string CreateCommaSeparatedLoopWithMetricValues(string loop, RacetrackMetrics metrics)
        {
            return loop + "," + metrics.FullLength + "," + metrics.NumberOfTurns + "," + metrics.NumberOfStraights + "," + metrics.NumberOfSuperStraights + "," + metrics.NumberOfConsecutiveTurns + "," + metrics.AverageSuperStraightLength + "," + metrics.AverageConsecutiveTurns;
        }
    }
}
