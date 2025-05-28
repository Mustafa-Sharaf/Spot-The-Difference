using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotDifferenceGames.GameLogic
{
    public static class ImageDifferenceChecker
    {
        public static bool IsRegionDifferent(Bitmap left, Bitmap right, int centerX, int centerY, int regionSize = 20, int threshold = 30)
        {
            int half = regionSize / 2;
            int diffSum = 0;
            int count = 0;

            for (int y = -half; y <= half; y++)
            {
                for (int x = -half; x <= half; x++)
                {
                    int px = centerX + x;
                    int py = centerY + y;

                    if (px < 0 || py < 0 || px >= left.Width || py >= left.Height) continue;

                    Color c1 = left.GetPixel(px, py);
                    Color c2 = right.GetPixel(px, py);
                    diffSum += ColorDifference(c1, c2);
                    count++;
                }
            }

            int averageDiff = diffSum / count;
            return averageDiff > threshold;
        }

        private static int ColorDifference(Color c1, Color c2)
        {
            return Math.Abs(c1.R - c2.R) + Math.Abs(c1.G - c2.G) + Math.Abs(c1.B - c2.B);
        }
    }

}
