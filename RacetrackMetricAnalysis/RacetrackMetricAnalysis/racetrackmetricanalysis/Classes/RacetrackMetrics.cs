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
        private int _fullLength;
        public int FullLength { get { return _fullLength; } }
        private float _avgSuperStraightLength;
        public float AverageSuperStraightLength { get { return _avgSuperStraightLength; } }
        private float _avgConsecutiveTurns;
        public float AverageConsecutiveTurns { get { return _avgConsecutiveTurns; } }
        private float _straightsRatio;
        public float StraightsRatio { get { return _straightsRatio; } }
        private float _sGrade;
        public float SpeedGrade { get { return _sGrade; } }
        private float _aGrade;
        public float AgilityGrade { get { return _aGrade; } }

        public RacetrackMetrics(int numberOfTurns, int numberOfStraights, int numberOfSuperStraights, int numberOfConsecutiveTurns)
        {
            NumberOfTurns = numberOfTurns;
            NumberOfStraights = numberOfStraights;
            NumberOfSuperStraights = numberOfSuperStraights;
            NumberOfConsecutiveTurns = numberOfConsecutiveTurns;

            _fullLength = NumberOfTurns + NumberOfStraights;

            if (NumberOfSuperStraights == 0) _avgSuperStraightLength = 0f;
            else _avgSuperStraightLength = (float)numberOfStraights / (float)numberOfSuperStraights;

            if (NumberOfConsecutiveTurns == 0) _avgConsecutiveTurns = 0f;
            else _avgConsecutiveTurns = (float)numberOfTurns / (float)NumberOfConsecutiveTurns;

            _straightsRatio = (float)NumberOfStraights / (float)_fullLength;
            var turnsRatio = 1 - _straightsRatio;

            if (_fullLength > 20)
            {
                _aGrade = -1;
                _sGrade = -1;
            }
            else
            {
                _sGrade = .22f * _straightsRatio + .013f * (_avgSuperStraightLength * _avgSuperStraightLength * (float)Math.Sqrt(NumberOfSuperStraights * NumberOfSuperStraights * NumberOfSuperStraights));
                _aGrade = .22f * turnsRatio + .0045f * (_avgConsecutiveTurns * _avgConsecutiveTurns * NumberOfConsecutiveTurns);
            }
        }
    }
}
