using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacetrackMetricAnalysis.Classes;

namespace RacetrackMetricAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            RacetrackAnalyzer analyzer = new RacetrackAnalyzer();

            for (int i = 2; i < 7; i++)
            {
                int endJValue = (i == 6) ? 6 : 7;
                for (int j = i; j <= endJValue; j++)
                {
                    Console.WriteLine("Starting " + i + "x" + j + "...");

                    string[] loops = System.IO.File.ReadAllLines(@"C:\Users\Jake\Documents\RacetrackMetricAnalysis\RacetrackMetricAnalysis\racetrackmetricanalysis\Loops\Loops_" + i + "x" + j + ".txt");

                    ProcessMetrics(loops, analyzer);

                    System.IO.File.WriteAllLines(@"C:\Users\Jake\Documents\RacetrackMetricAnalysis\RacetrackMetricAnalysis\racetrackmetricanalysis\LoopsWithMetrics\Loops_" + i + "x" + j + ".txt", loops);

                    Console.WriteLine("Finished " + i + "x" + j + "!");
                }
            }
        }

        static void ProcessMetrics(string[] loops, RacetrackAnalyzer analyzer)
        {
            RacetrackMetrics metrics;
            int endStraights = 0, endSuperStraights = 0, endTurns = 0, endConsecutiveTurns = 0, longestSuperStraight = 0, longestConsecutiveTurns = 0;

            for (int i = 0; i < loops.Length; i++)
            {
                metrics = analyzer.GetMetrics(loops[i]);
                endStraights += metrics.NumberOfStraights;
                endSuperStraights += metrics.NumberOfSuperStraights;
                endTurns += metrics.NumberOfTurns;
                endConsecutiveTurns+=metrics.NumberOfConsecutiveTurns;
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
            string result = "Straight Aways: "+endStraights+"\n"+"Super Straight Aways: "+endSuperStraights+"\n"+"Turns: "+endTurns+"\n"
                +"Consecutive Turns: "+endConsecutiveTurns+"\n"+"Longest Super Straight: "+longestSuperStraight+"\n"+"Longest Consecutive Turn: "+longestConsecutiveTurns;
            System.IO.File.WriteAllText(@"C:\Users\Jake\Documents\RacetrackMetricAnalysis\RacetrackMetricAnalysis\racetrackmetricanalysis\OutputMetrics\Results.txt", result);
        }

        static string CreateCommaSeparatedLoopWithMetricValues(string loop, RacetrackMetrics metrics)
        {
            return loop + "," + metrics.NumberOfTurns + "," + metrics.NumberOfStraights+","+metrics.NumberOfSuperStraights;
        }
    }
}
