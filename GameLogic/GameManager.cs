using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotDifferenceGames.GameLogic
{
    public class GameManager
    {
        public int Level { get; set; }
        public int WrongAttempts { get; private set; }
        public const int MaxWrongAttempts = 6;
        private List<Point> discoveredDifferences = new List<Point>();

        public GameManager(int level)
        {
            Level = level;
        }

        public void Reset()
        {
            WrongAttempts = 0;
            discoveredDifferences.Clear();
        }

        public bool RegisterClick(Point location, bool isDifference)
        {
            if (isDifference && !discoveredDifferences.Contains(location))
            {
                discoveredDifferences.Add(location);
                return true;
            }
            else if (!isDifference)
            {
                WrongAttempts++;
            }

            return false;
        }

        public int GetRemainingDifferences(int totalDifferences = 5) => totalDifferences - discoveredDifferences.Count;
        public int GetDiscoveredCount() => discoveredDifferences.Count;

        public bool HasExceededAttempts() => WrongAttempts >= MaxWrongAttempts;
    }

}
