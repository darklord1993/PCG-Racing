using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacetrackMetricAnalysis.Classes
{
    public class RacetrackAnalyzer
    {
        // Blank constructor
        public RacetrackAnalyzer() { }

        public RacetrackMetrics GetMetrics(string racetrack)
        {
            int numberOfTurns = 0, numberOfStraights = 0, numberOfSuperStraights = 0, numberOfConsecutiveTurns = 0;

            bool Superstraight = false;
            bool ConsecutiveTurn = false;

            for (int i = 0; i < racetrack.Length; i++)
            {
                if (racetrack[i] != 's')
                {
                    Superstraight = false;
                    numberOfTurns++;
                    if (i > 0)
                    {
                        if (racetrack[i - 1] != 's')
                        {
                            if (!ConsecutiveTurn)
                            {
                                numberOfConsecutiveTurns++;
                                ConsecutiveTurn = true;
                            }
                        }
                    }
                }
                else
                {
                    ConsecutiveTurn = false;
                    numberOfStraights++;
                    if (racetrack[i - 1] == 's')
                    {
                    }
                    else
                    {
                        if (!Superstraight)
                        {
                            Superstraight = true;
                            numberOfSuperStraights++;
                        }
                    }
                }
            }

            RacetrackMetrics metrics = new RacetrackMetrics(numberOfTurns, numberOfStraights, numberOfSuperStraights, numberOfConsecutiveTurns);

            return metrics;
        }
    }
}
