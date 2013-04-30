using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AdvancedMathOperations
{
    class SqrtTests
    {
        public static void SqrtOfFloat(float startValue, float endValue, float offset)
        {
            for (float i = startValue; i <= endValue; i += offset)
            {
                Math.Sqrt(i);
            }
        }

        public static void SqrtOfDecimal(decimal startValue, decimal endValue, decimal offset)
        {
            for (decimal i = startValue; i <= endValue; i += offset)
            {
                Math.Sqrt((double)i);
            }
        }

        public static void SqrtOfDouble(double startValue, double endValue, double offset)
        {
            for (double i = startValue; i <= endValue; i += offset)
            {
                Math.Sqrt(i);
            }
        }

    }
}
