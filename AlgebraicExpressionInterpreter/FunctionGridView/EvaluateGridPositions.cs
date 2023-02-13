using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionGridView
{
    public class EvaluateGridPositions
    {
        public static IEnumerable<double> EvaluateVerticalGridPositions(double rangeStart, double rangeEnd, int n)
        {
            if(n==0 || n==rangeEnd || n < rangeEnd)
            {
                throw new InvalidOperationException("n is not valid.");
            }

            double delta = (rangeEnd - rangeStart) / n;
            int factor = 1;

            if (delta < 1)
            {
                while (delta < 1)
                {
                    delta *= 10;
                    factor *= 10;
                }
            }
            else if (delta >= 10)
            {
                while (delta >= 10)
                {
                    delta /= 10;
                    factor *= 10;
                }
            }
            double deltaGrid = (int)(delta / factor) * factor;
           double startGrid = (int)(rangeStart / factor) * factor;

            List<double> gridPoints = new List<double>();
            double gridPoint = startGrid;
            for (int i = 0; i < n; ++i)
            {
                gridPoint += deltaGrid;
                gridPoints.Add(gridPoint);
            }

            return gridPoints;
        }
    }
}
