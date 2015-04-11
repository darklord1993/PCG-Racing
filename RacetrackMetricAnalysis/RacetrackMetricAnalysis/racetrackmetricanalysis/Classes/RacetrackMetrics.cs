using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacetrackMetricAnalysis.Classes
{
    public class RacetrackMetrics
    {
        public int NumberOfTurns { get; private set; }
        public int NumberOfStraights { get; private set; }
        public int NumberOfSuperStraights { get; set; }
        public int NumberOfConsecutiveTurns { get; set; }

        public RacetrackMetrics(int numberOfTurns, int numberOfStraights, int numberOfSuperStraights, int numberOfConsecutiveTurns)
        {
            NumberOfTurns = numberOfTurns;
            NumberOfStraights = numberOfStraights;
            NumberOfSuperStraights = numberOfSuperStraights;
            NumberOfConsecutiveTurns = numberOfConsecutiveTurns;
        }
    }
}
