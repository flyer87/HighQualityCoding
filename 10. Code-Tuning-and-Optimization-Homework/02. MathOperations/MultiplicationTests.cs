using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations
{
    static class MultiplicationTests
    {
        public static void MultiplyInt(int startValue, int endValue, int offset)
        {
            for (int i = startValue; i <= endValue; i *= offset) { }
        }

        public static void MultiplyLong(long startValue, long endValue, long offset)
        {
            for (long i = startValue; i <= endValue; i *= offset) { }
        }

        public static void MultiplyDecimal(decimal startValue, decimal endValue, decimal offset)
        {
            for (decimal i = startValue; i <= endValue; i *= offset) { }
        }

        public static void MultiplyFloat(float startValue, float endValue, float offset)
        {
            for (float i = startValue; i <= endValue; i *= offset) { }
        }

        public static void MultiplyDouble(double startValue, double endValue, double offset)
        {
            for (double i = startValue; i <= endValue; i *= offset) { }
        }
    }
}
