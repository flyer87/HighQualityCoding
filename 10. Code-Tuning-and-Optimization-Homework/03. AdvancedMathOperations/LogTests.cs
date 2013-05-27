using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AdvancedMathOperations
{
    class LogTests
    {
        public static void LogOfFloat(float startValue, float endValue, float offset)
        {
            for (float i = startValue; i <= endValue; i += offset)
            {
                Math.Log(i);
            }
        }

        public static void LogOfDecimal(decimal startValue, decimal endValue, decimal offset)
        {
            for (decimal i = startValue; i <= endValue; i += offset)
            {
                Math.Log((double)i);
            }
        }

        public static void LogOfDouble(double startValue, double endValue, double offset)
        {
            for (double i = startValue; i <= endValue; i += offset)
            {
                Math.Log(i);
            }
        }

    }
}
