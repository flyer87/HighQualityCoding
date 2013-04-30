using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations
{
    class SubstractionTests
    {
        public static void SubstractInt(int startValue, int endValue, int offset)
        {
            for (int i = startValue; i <= endValue; i -= offset) { }
        }

        public static void SubstractLong(long startValue, long endValue, long offset)
        {
            for (long i = startValue; i <= endValue; i -= offset) { }
        }

        public static void SubstractDecimal(decimal startValue, decimal endValue, decimal offset)
        {
            for (decimal i = startValue; i <= endValue; i -= offset) { }
        }

        public static void SubstractFloat(float startValue, float endValue, float offset)
        {
            for (float i = startValue; i <= endValue; i -= offset) { }
        }

        public static void SubstractDouble(double startValue, double endValue, double offset)
        {
            for (double i = startValue; i <= endValue; i -= offset) { }
        }
    }
}
